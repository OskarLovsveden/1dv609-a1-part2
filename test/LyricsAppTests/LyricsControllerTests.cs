using Xunit;
using Moq;
using Model;
using Model.DAL;
using Controller;
using View;
using View.utils;

namespace LyricsAppTests
{
    public class LyricsControllerTests
    {
        [Fact]
        public void Run_MenuOptionShowMenu_ShouldCallShowMainMenuGetUserSelection()
        {
            Mock<IMenu> mockMenu = new Mock<IMenu>();
            LyricsController sut = GetSystemUnderTest(MenuOption.ShowMenu, mockMenu);

            sut.Run();

            mockMenu.Verify(menu => menu.ShowMainMenuGetUserSelection());
        }

        [Fact]
        public void Run_MenuOptionSelectSong_ShouldCallGetArtist()
        {
            Mock<IMenu> mockMenu = new Mock<IMenu>();
            LyricsController sut = GetSystemUnderTest(MenuOption.SelectSong, mockMenu);

            sut.Run();

            mockMenu.Verify(menu => menu.GetArtist());
        }

        [Fact]
        public void Run_MenuOptionSelectSong_ShouldCallGetSongTitle()
        {
            Mock<IMenu> mockMenu = new Mock<IMenu>();
            LyricsController sut = GetSystemUnderTest(MenuOption.SelectSong, mockMenu);

            sut.Run();

            mockMenu.Verify(menu => menu.GetSongTitle());
        }

        [Fact]
        public void Run_MenuOptionSelectSong_ShouldCallGetSong()
        {
            Mock<IAppState> mockAppState = GetAppStateMock_CurrentState(MenuOption.SelectSong);

            Mock<IMenu> mockMenu = new Mock<IMenu>();
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            LyricsController sut = new LyricsController(mockAppState.Object, mockMenu.Object, mockSongDAL.Object);
            sut.Run();

            mockSongDAL.Verify(songDAL => songDAL.GetSong(It.IsAny<IArtist>(), It.IsAny<ITitle>()));
        }
        [Fact]
        public void Run_MenuOptionSelectSong_ShouldCallExit()
        {
            Mock<IAppState> mockAppState = GetAppStateMock_CurrentState(MenuOption.Quit);

            Mock<IMenu> mockMenu = new Mock<IMenu>();
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            LyricsController sut = new LyricsController(mockAppState.Object, mockMenu.Object, mockSongDAL.Object);
            sut.Run();

            mockAppState.Verify(appState => appState.Exit());
        }

        private LyricsController GetSystemUnderTest(MenuOption menuOption, Mock<IMenu> menuMock)
        {
            Mock<IAppState> mockAppState = GetAppStateMock_CurrentState(menuOption);
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            return new LyricsController(mockAppState.Object, menuMock.Object, mockSongDAL.Object);
        }

        private Mock<IAppState> GetAppStateMock_CurrentState(MenuOption menuOption)
        {
            Mock<IAppState> mockAppState = new Mock<IAppState>();
            mockAppState.SetupSequence(state => state.ShouldRun)
            .Returns(true)
            .Returns(false);
            mockAppState.Setup(state => state.Current).Returns(menuOption);

            return mockAppState;
        }
    }
}