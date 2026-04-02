using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


/// <summary>
/// this class is use to store user related information  like age,price, membertype , username, steps, active days, intensity
/// with method/functions like :
///  - CalculateFinalPrice which which takes age and member type before Calculating  discount in the final price
///  - PlankChallenge with increment of 10 sec every round till 60 seconds
///  - CalculateBMI to calculate bmi using heignt and weight
///  - RunLaps to run laps with reminder to drink the water
///  - GetWorkoutType returns the workout type based on user intensity
///  - to unlock pro medal based on user steps and active days
/// This class is designed to support the business logic of the
/// Fitness Tracker web application.
/// </summary>
namespace UserLib
{
    public class User
    {
        private int age;
        public int Price = 50;
        public string MemberType; // "Senior", or "Student", or "Regular"
        public string UserName { get; }   // read only user name
        public int Steps;
        public int ActiveDays;//should be greater than 40
        public int Intensity; // 1, 2, or 3

        // Constructor with Username set once
        public User(string username)
        {
            this.UserName = username;
        }

        // Manual Property with validation logic
        public int Age
        {
            #region
            get
            {
                return age;
            }
            set
            {
                #region
                if (value >= 0 && value <= 120)
                {
                    age = value;
                }
                else
                {
                    age = 18;
                }
                #endregion
            }
            #endregion
        }

        // Read-only Username property
        public string Username
        {
            get { return UserName; }
        }

        // 1. Calculate membership price with discount based in age( if greater than or equal to 65) and membertyoe ( if student )
        public double CalculateFinalPrice(int Age, string MemberType)
        {
            double finalPrice;
            #region
            if (Age >= 65 || MemberType == "Student")
            {
                finalPrice = Price-(Price * 0.20);
            }
            else
            {
                finalPrice = Price;
            }
            #endregion
            return finalPrice;
        }

        // 2. Plank Challenge using while loop with increment of 10 sec on every iteration till 60 seconds
        public void PlankChallenge()
        {
            int time = 10;

            while (time <= 60)
            {
                #region
                HttpContext.Current.Response.Write("Hold plank for " + time + "s</br>");
                time += 10;
                #endregion
            }
        }

        // 3. BMI Calculation Method
        public double CalculateBMI(double weightKg, double heightM)
        {
            if (heightM <= 0)
                return 0;

            return weightKg / (heightM * heightM);
        }

        // 4. Running laps with drink water message on lap 3
        public void RunLaps()
        {
            for (int lap = 1; lap <= 5; lap++)
            {
                #region
                HttpContext.Current.Response.Write("Lap " + lap + "<br>");

                if (lap == 3)
                {
                    HttpContext.Current.Response.Write("Drink water <br>");
                }
                #endregion
            }
        }

        // 5. Workout assignment using switch based on intensity of user
        public string GetWorkoutType(int Intensity)
        {
            string workout;

            switch (Intensity)
            {
                #region
                case 1:
                    workout = "Walk";
                    break;
                case 2:
                    workout = "Jog";
                    break;
                case 3:
                    workout = "Run";
                    break;
                default:
                    workout = "Unknown";
                    break;
                #endregion
            }

            return workout;
        }

        // 6. Pro Medal unlock condition if steps are more thatn 10000 and is active form more than 30 days
        public bool UnlockProMedal(double Steps, int ActiveDays)
        {
            if (Steps > 10000 && ActiveDays > 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
