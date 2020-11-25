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
            Mock<IAppState> mockAppState = GetAppStateMock_CurrentState(MenuOption.ShowMenu);

            Mock<IMenu> mockMenu = new Mock<IMenu>();
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            LyricsController sut = new LyricsController(mockAppState.Object, mockMenu.Object, mockSongDAL.Object);
            sut.Run();

            mockMenu.Verify(menu => menu.ShowMainMenuGetUserSelection());
        }

        [Fact]
        public void Run_MenuOptionSelectSong_ShouldCallGetArtist()
        {
            Mock<IAppState> mockAppState = GetAppStateMock_CurrentState(MenuOption.SelectSong);

            Mock<IMenu> mockMenu = new Mock<IMenu>();
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            LyricsController sut = new LyricsController(mockAppState.Object, mockMenu.Object, mockSongDAL.Object);
            sut.Run();

            mockMenu.Verify(menu => menu.GetArtist());
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