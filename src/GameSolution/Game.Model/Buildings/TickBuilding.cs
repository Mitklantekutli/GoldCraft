namespace Game.Model.Buildings
{
    public abstract class TickBuilding
    {
        public double RefreshTime = -1;
        public double RefreshTimeLeft = -1;
        public Building Building { get; set; }

        protected TickBuilding(double time)
        {
            RefreshTime = time;
            RefreshTimeLeft = time;
        }

        public void OnTick(double delta)
        {
            RefreshTimeLeft -= delta;
            if (RefreshTimeLeft <= 0)
            {
                RefreshTimeLeft = RefreshTime;
                OnEvent();
            }
        }

        public abstract void OnEvent();
    }
}
