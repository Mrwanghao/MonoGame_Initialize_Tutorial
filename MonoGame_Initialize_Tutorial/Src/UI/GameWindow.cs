using Nez;
using Nez.UI;

namespace UI
{
    public class GameWindow : UIBase
    {
        protected override Entity CreateEntity()
        {
            return Core.scene.createEntity("GameWindow");
        }

        protected override Table CreateTable()
        {
            Table table = new Table();
            return table;
        }

        protected override UICanvas CreateUICanvas()
        {
            UICanvas canvas = new UICanvas();
            canvas.isFullScreen = true;
            return canvas;
        }
    }
}
