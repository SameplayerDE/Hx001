namespace Hx001.Framework.Physics2D
{
    public class Spring
    {

        public Particle A;
        public Particle B;
        public float Stiffness;
        public float Lenght;

        public Spring(Particle a, Particle b, float stiffness, float lenght)
        {
            A = a;
            B = b;
            Stiffness = stiffness;
            Lenght = lenght;
        }

    }
}