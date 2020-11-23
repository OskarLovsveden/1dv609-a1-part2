using System;
using Xunit;
using System.Net.Http;
using Moq;
using Model.DAL;
using Model;
using System.Threading.Tasks;

namespace LyricsAppTests
{
    public class MusixMatchDALTests
    {
        [Theory]
        [InlineData("ABBA", "Waterloo", "86797692")]
        public void GetTrack_SongInfo_ReturnsTrackInstance(string artistName, string songTitle, string trackID)
        {
            Mock<IFetch> mockFetch = new Mock<IFetch>();
            Mock<IArtist> mockArtist = new Mock<IArtist>();
            Mock<ITitle> mockTitle = new Mock<ITitle>();

            Task<HttpResponseMessage> fakeResponseMessage = GetFakeResponeMessage(GetFakeTrackResponse());

            mockFetch.Setup(fetch => fetch.GetAsync(It.IsAny<string>())).Returns(fakeResponseMessage);
            mockArtist.Setup(artist => artist.Name).Returns(artistName);
            mockTitle.Setup(songTitle => songTitle.Name).Returns(songTitle);

            MusixMatchDAL sut = new MusixMatchDAL(mockFetch.Object);

            Track expected = new Track(trackID);

            Track actual = sut.GetTrack(mockArtist.Object, mockTitle.Object).Result;

            Assert.Equal(expected.ID, actual.ID);
        }

        private Task<HttpResponseMessage> GetFakeResponeMessage(string fakeContent)
        {
            HttpContent content = new StringContent(fakeContent);
            return Task.FromResult(new HttpResponseMessage { Content = content });
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
    }
}