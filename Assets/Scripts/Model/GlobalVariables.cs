using Utilities;

namespace Model
{
    public class GlobalVariables : Singleton<GlobalVariables>
    {
        public GlobalConstants.GameStates GameState { get; set; } = GlobalConstants.GameStates.PreGame;
        public GlobalConstants.WindowStates WindowState { get; set; } = GlobalConstants.WindowStates.MainMenu;
    }
}
