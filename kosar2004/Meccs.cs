namespace kosar2004
{
    internal class Meccs
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int HPont { get; private set; }
        public int IPont { get; private set; }
        public string Hely { get; private set; }
        public string Ido { get; private set; }

        public string Atalakit()
        {
            return Hazai + " - " + Idegen + " ("+HPont+":"+IPont+")";
        }

        public Meccs(string hazai, string idegen, int hpont, int ipont, string hely, string ido)
        {
            this.Hazai = hazai;
            this.Idegen = idegen;
            this.HPont = hpont;
            this.IPont = ipont;
            this.Hely = hely;
            this.Ido = ido;
        }
    }
}