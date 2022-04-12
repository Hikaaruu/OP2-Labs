
namespace OP
{
    public class Time
    {
        public Time(int _hours, int _minutes, int _seconds)
        {
            if (_hours < 0 || _hours >= 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours));
            }

            if (_minutes < 0 || _minutes >= 60)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes));
            }

            if (_seconds < 0 || _seconds >= 60)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds));
            }

            hours = _hours;
            minutes = _minutes;
            seconds = _seconds;
        }

        public Time(int _hours, int _minutes)
        {
            if (_hours < 0 || _hours >= 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours));
            }

            if (_minutes < 0 || _minutes >= 60)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes));
            }

            hours = _hours;
            minutes = _minutes;
        }

        public Time(int _hours)
        {
            if (_hours < 0 || _hours >= 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours));
            }

            hours = _hours;
        }

        public Time()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }



        private int hours;
        public int Hours { get; set; }

        private int minutes;
        public int Minutes { get; set; }

        private int seconds;
        public int Seconds { get; set; }

        public static bool operator >(Time left, Time right)
        {
            if (left.hours > right.hours)
            {
                return true;
            }

            else if (left.hours == right.hours)
            {
                if (left.minutes > right.minutes)
                {
                    return true;
                }

                else if (left.minutes == right.minutes)
                {
                    if (left.seconds > right.seconds)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public static bool operator <(Time left, Time right)
        {
            if (left.hours < right.hours)
            {
                return true;
            }

            else if (left.hours == right.hours)
            {
                if (left.minutes < right.minutes)
                {
                    return true;
                }

                else if (left.minutes == right.minutes)
                {
                    if (left.seconds < right.seconds)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public static bool operator ==(Time left, Time right)
        {
            if (left.hours == right.hours && left.minutes == right.minutes && left.seconds == right.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Time left, Time right)
        {
            if (!(left.hours == right.hours && left.minutes == right.minutes && left.seconds == right.seconds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Time operator ++(Time time)
        {
            Time result = new Time(time.hours, time.minutes, time.seconds);
            result.seconds += 1;
            return result;
        }

        // -- instead of prefix++, because you cant override this operator in c#
        public static Time operator --(Time time)
        {
            Time result = new Time(time.hours, time.minutes, time.seconds);
            result.minutes += 1;
            return result;
        }

        public Time TimeLeftFor(Time end)
        {
            int minutes;
            int hours;

            int start_seconds = this.seconds + this.minutes * 60 + this.hours * 3600;
            int end_seconds = end.seconds + end.minutes * 60 + end.hours * 3600;
            int result = end_seconds - start_seconds;

            if (result >= 0)
            {
                hours = result / 3600;
                result %= 3600;
                minutes = result / 60;
                result %= 60;

                return new Time(hours, minutes, result);
            }

            else
            {
                result += 24 * 3600;

                hours = result / 3600;
                result %= 3600;
                minutes = result / 60;
                result %= 60;

                return new Time(hours, minutes, result);
            }
        }

        public override string ToString()
        {
            string hours = Convert.ToString(this.hours);
            string minutes = Convert.ToString(this.minutes);
            string seconds = Convert.ToString(this.seconds);
            if (this.hours < 10)
            {
                hours = "0" + hours;
            }

            if (this.minutes < 10)
            {
                minutes = "0" + minutes;
            }

            if (this.seconds < 10)
            {
                seconds = "0" + seconds;
            }

            return hours + ":" + minutes + ":" + seconds;
        }

    }
}
