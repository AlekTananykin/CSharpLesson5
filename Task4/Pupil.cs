namespace Task4
{
    public class Pupil
    {
        public Pupil()
        {
            _averageEstimate = -1;
        }

        public string Surname { get; set; }
        public string Name { get; set; }

        private int _averageEstimate;

        public int Estimate1 { get; set; }

        public int Estimate2 { get; set; }
        public int Estimate3 { get; set; }

        public int AverageEstimate
        {
            get 
            {
                if (_averageEstimate < 1)
                    _averageEstimate = 
                        (Estimate1 + Estimate2 + Estimate3) / 3;

                return _averageEstimate;
            }
        }
    }
}