using Nez;


namespace Components
{
    public class BuilderFollow : Component, IUpdatable
    {
        public void update()
        {
            transform.setPosition(Vector2Ext.transform(Input.mousePosition, Core.scene.camera.inverseTransformMatrix));
        }

    }
}
