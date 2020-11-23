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
    public class MusixMatchDALTests
    {
        [Theory]
        [InlineData("ABBA", "Waterloo", "86797692")]
        public async void GetTrack_SongInfo_ReturnsTrackInstance(string artistName, string songTitle, string trackID)
        {
            Mock<IArtist> mockArtist = GetMockArtist(artistName);
            Mock<ITitle> mockTitle = GetMockTitle(songTitle);

            string fakeTrackResponse = GetFakeTrackResponse();
            Task<HttpResponseMessage> fakeResponse = GetFakeResponseMessageSuccess(fakeTrackResponse);
            MusixMatchDAL sut = GetSystemUnderTest(fakeResponse);

            string expected = trackID;
            Track actual = await sut.GetTrack(mockArtist.Object, mockTitle.Object);

            Assert.Equal(expected, actual.ID);
        }

        [Theory]
        [InlineData("AbcAbcAbc", "AbcAbcAbc")]
        public async void GetTrack_SongInfo_ThrowsOnTrackNotFound(string artistName, string songTitle)
        {
            Mock<IArtist> mockArtist = GetMockArtist(artistName);
            Mock<ITitle> mockTitle = GetMockTitle(songTitle);

            Task<HttpResponseMessage> fakeResponse = GetFakeResponseMessageFailed();
            MusixMatchDAL sut = GetSystemUnderTest(fakeResponse);

            await Assert.ThrowsAsync<TrackNotFoundException>(() => sut.GetTrack(mockArtist.Object, mockTitle.Object));
        }

        [Theory]
        [InlineData("ABBA", "Waterloo", "86797692")]
        public async void GetSong_Track_ReturnsSongInstance(string artistName, string songTitle, string trackID)
        {
            Mock<ITrack> mockTrack = new Mock<ITrack>();
            Mock<IArtist> mockArtist = GetMockArtist(artistName);
            Mock<ITitle> mockTitle = GetMockTitle(songTitle);

            mockTrack.Setup(track => track.ID).Returns(trackID);

            string fakeLyricResponse = GetFakeLyricResponse();
            Task<HttpResponseMessage> fakeResponse = GetFakeResponseMessageSuccess(fakeLyricResponse);
            MusixMatchDAL sut = GetSystemUnderTest(fakeResponse);

            string expected = artistName;

            Song actual = await sut.GetSong(artistName, songTitle, trackID);

            Assert.Equal(expected, actual.GetArtistName());
        }

        private MusixMatchDAL GetSystemUnderTest(Task<HttpResponseMessage> fakeResponseMessage)
        {
            Mock<IFetch> mockFetch = new Mock<IFetch>();
            mockFetch.Setup(fetch => fetch.GetAsync(It.IsAny<string>())).Returns(fakeResponseMessage);
            return new MusixMatchDAL(mockFetch.Object);
        }

        private Task<HttpResponseMessage> GetFakeResponseMessageSuccess(string responseContent)
        {
            HttpContent content = new StringContent(responseContent);
            return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = content });
        }

        private Task<HttpResponseMessage> GetFakeResponseMessageFailed()
        {
            HttpContent content = new StringContent("fakeContent");
            return Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden, Content = content });
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

        private string GetFakeTrackResponse()
        {
            return @"callback({
                'message': {
                    'header': {
                        'status_code': 200,
                        'execute_time': 0.015722036361694,
                        'confidence': 900,
                        'mode': 'search',
                        'cached': 1
                    },
                    'body': {
                        'track': {
                            'track_id': 86797692,
                            'track_name': 'Waterloo',
                            'track_name_translation_list': [],
                            'track_rating': 27,
                            'commontrack_id': 14924231,
                            'instrumental': 0,
                            'explicit': 0,
                            'has_lyrics': 1,
                            'has_subtitles': 1,
                            'has_richsync': 1,
                            'num_favourite': 2881,
                            'album_id': 21657053,
                            'album_name': 'Journals',
                            'artist_id': 33491916,
                            'artist_name': 'ABBA',
                            'track_share_url': 'https:\/\/www.musixmatch.com\/lyrics\/Justin-Bieber\/One-Life?utm_source=application&utm_campaign=api&utm_medium=Oskar+L%C3%B6vsveden%3A1409620788344',
                            'track_edit_url': 'https:\/\/www.musixmatch.com\/lyrics\/Justin-Bieber\/One-Life\/edit?utm_source=application&utm_campaign=api&utm_medium=Oskar+L%C3%B6vsveden%3A1409620788344',
                            'restricted': 0,
                            'updated_time': '2019-10-02T19:12:20Z',
                            'primary_genres': {
                                'music_genre_list': [
                                    {
                                        'music_genre': {
                                            'music_genre_id': 14,
                                            'music_genre_parent_id': 34,
                                            'music_genre_name': 'Pop',
                                            'music_genre_name_extended': 'Pop',
                                            'music_genre_vanity': 'Pop'
                                        }
                                    }
                                ]
                            }
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
    }
}