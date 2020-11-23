using CustomException;
using Xunit;
using System.Net.Http;
using Moq;
using Model.DAL;
using Model;
using System.Threading.Tasks;
using System.Net;

namespace LyricsAppTests
{
    public class SongDALTests
    {
        [Theory]
        [InlineData("ABBA", "Waterloo", "86797692")]
        public async void GetSong_Track_ReturnsSongInstance(string artistName, string songTitle, string trackID)
        {
            Mock<ITrackID> mockTrackID = GetMockTrackID(trackID);
            Mock<IArtist> mockArtist = GetMockArtist(artistName);
            Mock<ITitle> mockTitle = GetMockTitle(songTitle);

            string fakeLyricResponse = GetFakeLyricResponse();
            Task<HttpResponseMessage> fakeResponse = GetFakeResponseMessageSuccess(fakeLyricResponse);


            SongDAL sut = GetSystemUnderTest(fakeResponse, mockArtist, mockTitle, mockTrackID);
            Song song = await sut.GetSong(mockArtist.Object, mockTitle.Object);


            string expected = artistName;
            string actual = song.GetArtistName();



            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("12415125124", "(/)(/)(/)(/))", "*^*^*^```")]
        public async void GetSong_SongInfo_ThrowsOnSongNotFound(string artistName, string songTitle, string trackID)
        {
            Mock<IArtist> mockArtist = GetMockArtist(artistName);
            Mock<ITitle> mockTitle = GetMockTitle(songTitle);
            Mock<ITrackID> mockTrackID = GetMockTrackID(trackID);



            Task<HttpResponseMessage> fakeResponse = GetFakeResponseMessageFailed();
            SongDAL sut = GetSystemUnderTest(fakeResponse, mockArtist, mockTitle, mockTrackID);

            await Assert.ThrowsAsync<SongNotFoundException>(() => sut.GetSong(mockArtist.Object, mockTitle.Object));
        }

        private SongDAL GetSystemUnderTest(Task<HttpResponseMessage> fakeResponseMessage, Mock<IArtist> artist, Mock<ITitle> title, Mock<ITrackID> trackID)
        {
            Mock<IFetch> mockFetch = new Mock<IFetch>();
            Mock<ITrackDAL> mockTrackDAL = new Mock<ITrackDAL>();

            mockTrackDAL.Setup(track => track.GetTrack(artist.Object, title.Object)).Returns(Task.FromResult(new TrackID(trackID.Object.Value)));
            mockFetch.Setup(fetch => fetch.GetAsync(It.IsAny<string>())).Returns(fakeResponseMessage);

            return new SongDAL(mockFetch.Object, mockTrackDAL.Object);
        }
        private Task<HttpResponseMessage> GetFakeResponseMessageFailed()
        {
            HttpContent content = new StringContent("fakeContent");
            return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden, Content = content });
        }

        private Task<HttpResponseMessage> GetFakeResponseMessageSuccess(string responseContent)
        {
            HttpContent content = new StringContent(responseContent);
            return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = content });
        }

        private string GetFakeLyricResponse()
        {
            return @"callback({
                    ""message"":{
                        ""header"":{
                            ""status_code"":200,
                            ""execute_time"":0.014976024627686
                        },
                        ""body"":{
                            ""lyrics"":{
                                ""lyrics_id"":19832103,
                                ""explicit"":0,
                                ""lyrics_body"":""My, my\nAt Waterloo, Napoleon did surrender\nOh yeah\nAnd I have met my destiny in quite a similar way\nThe history book on the shelf\nIs always repeating itself\n\nWaterloo\nI was defeated, you won the war\nWaterloo\nPromise to love you for ever more\n\nWaterloo\nCouldn't escape if I wanted to\nWaterloo\nKnowing my fate is to be with you\n\nOh, oh, oh, oh, Waterloo\n...\n\n******* This Lyrics is NOT for Commercial use *******\n(1409620829342)"",
                                ""script_tracking_url"":""https:\/\/tracking.musixmatch.com\/t1.0\/m_js\/e_1\/sn_0\/l_19832103\/su_0\/rs_0\/tr_3vUCALb9uFOBVHWsGBgdovat7lPEsFC4j25hZ6hGcDjwY3p3hn4AxbHuxfFSGLM_xPgO2qmVODICvE7mYYqa4ul_xbnXLQuz2q-Wiu77LyHwPZnBbZElpkCOITvrMq-JNg1UjeCZewQfIUmuzgmg5XdPQ3AOJtnwZ9ckz5Vub0ozTXch2_kjb9wmu6XM9VdVb3gn1vDj9ksVCb9eF9O6KriXNKOCBsqHWZ5_EV94ZL2i9-UFLh89w2bVhvIcoxhnAOwVOroHXFlla7nteIKKXHAce2fLwsekMjPT1s2Xnzh-NWRMjU74D2j-z0CRqFy-Mx8x2J7ticdWvvxT9E7vJ90d2PY6UcwwtRLNY7aqsHgx0K073JhBpt9zt2Gx3tozoUTDtyu6EkfTAN5VkjK9bck_sJ7P-q-l0lE0wTu6A_EgQuA88Ea7Aw\/"",
                                ""pixel_tracking_url"":""https:\/\/tracking.musixmatch.com\/t1.0\/m_img\/e_1\/sn_0\/l_19832103\/su_0\/rs_0\/tr_3vUCAISM2EKhaUJqA1y3R0y8-VtabIdhdOMmSf5BLyXgn8UDzZ-hsNRNJF5ON1HJzzrVXOwv9OxVZmjjxyWmddIjJoUmbsPb_hZg-KHYNPrdjd8cnYzMNnIuoKkGwZ-6RFTKmGd3E5d54keFopYkLk_3iUdSW0_XRafhBaKuF-6nshwJTTmRkvD-ox_Th8cTq7lixer1fuZbdpopzIznVLPyUab_fDbtHiTniw58dkWyTU__9UJcpfSV2yFz3Xd-vuF2cugKkldS977eP0tLQB0i6Ii4r6MPggAbNl_01yU8xtDrbqeXdwEIL-XnGDfFjkPptZQsOlaj_nTXDwAcNbevWoLYJzSWKKoCJbBl-hD3x1gcPeLW9_xE_k-sviKIiAJ8NhrO3jfzMVQ2AgnkDjiW7PzvPzWujiUowBpz6yZx7DbeajWBfQ\/"",
                                ""lyrics_copyright"":""Lyrics powered by www.musixmatch.com. This Lyrics is NOT for Commercial use and only 30% of the lyrics are returned."",
                                ""updated_time"":""2020-11-22T13:15:25Z""
                            }
                        }
                    }
            });";
        }

        private Mock<IArtist> GetMockArtist(string name)
        {
            Mock<IArtist> mockArtist = new Mock<IArtist>();
            mockArtist.Setup(artist => artist.Name).Returns(name);

            return mockArtist;
        }
        private Mock<ITitle> GetMockTitle(string name)
        {
            Mock<ITitle> mockTitle = new Mock<ITitle>();
            mockTitle.Setup(songTitle => songTitle.Name).Returns(name);

            return mockTitle;
        }

        private Mock<ITrackID> GetMockTrackID(string id)
        {
            Mock<ITrackID> mockTrackID = new Mock<ITrackID>();
            mockTrackID.Setup(trackID => trackID.Value).Returns(id);

            return mockTrackID;
        }
    }
}