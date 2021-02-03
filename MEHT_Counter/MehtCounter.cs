using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEHT_Counter
{
    class MehtCounter
    { 
        double degree { get; set; }
        double minutes { get; set; }
        double seconds { get; set; }
        double papiThrDistance { get; set; }
        double papiAltitude { get; set; }
        double thrAltitude { get; set; }

        public MehtCounter(double degrees, double minutes, double seconds, double papiThr, double papiAlt, double thrAlt) {
            this.degree = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
            this.papiThrDistance = papiThr;
            this.papiAltitude = papiAlt;
            this.thrAltitude = thrAlt;
        }

        public double CountMehtInMeter() {
            double mehtNoThrPapi = (papiThrDistance * Math.Tan(TransformDecimalToRad(TransformDegreeIntoDecimal())));
            mehtNoThrPapi = Math.Round(mehtNoThrPapi, 1);

            double mehtTotal = mehtNoThrPapi + (papiAltitude - thrAltitude);
            mehtTotal = Math.Round(mehtTotal, 2);

            return mehtTotal;
        }

        public double ConvertMehtIntoFeet() {
            double mehtTotalFeet = CountMehtInMeter() / 0.3048;
            mehtTotalFeet = Math.Round(mehtTotalFeet, 2);

            return mehtTotalFeet;
        }

        private double TransformDegreeIntoDecimal()
        {
            double result;
            result = degree + (minutes / 60) + (seconds / 3600);

            return result;
        }

        private double TransformDecimalToRad(double decimalDegree)
        {
            double result;
            result = decimalDegree * (Math.PI / 180);

            return result;
        }
    }
}
