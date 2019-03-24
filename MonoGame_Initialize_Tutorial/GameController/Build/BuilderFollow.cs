using Nez;


namespace GameController.Build
{
    public class BuilderFollow : Component, IUpdatable
    {
        //bool enabled { get; }
        //int updateOrder { get; }

        public void update()
        {
            //Debug.log(2);
            transform.setPosition(Input.mousePosition);
        }

    }
}
