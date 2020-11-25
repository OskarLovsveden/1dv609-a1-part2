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
        public void Run_ShouldCallCorrectMethodDependentOnState()
        {
            Mock<IAppState> mockAppState = new Mock<IAppState>();
            mockAppState.Setup(state => state.ShouldRun).Returns(true);
            mockAppState.Setup(state => state.Current).Returns(MenuOption.ShowMenu);

            Mock<IMenu> mockMenu = new Mock<IMenu>();
            Mock<ISongDAL> mockSongDAL = new Mock<ISongDAL>();

            LyricsController sut = new LyricsController(mockAppState.Object, mockMenu.Object, mockSongDAL.Object);
            sut.Run();

            mockMenu.Verify(menu => menu.ShowMainMenuGetUserSelection());
        }
    }
}