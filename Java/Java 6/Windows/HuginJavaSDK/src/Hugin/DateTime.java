package Hugin;

import java.util.*;

public class DateTime {
  public int Year = 1;
  public int Month = 0;
  public int Day = 1;
  public int Hour = 0;
  public int Minute = 0;
  public int Second = 0;

  public DateTime() {
  }

  public DateTime(Calendar calendar) {
    Year = calendar.get(Calendar.YEAR);
    Month = calendar.get(Calendar.MONTH);
    Day = calendar.get(Calendar.DAY_OF_MONTH);
    Hour = calendar.get(Calendar.HOUR);
    Minute = calendar.get(Calendar.MINUTE);
    Second = calendar.get(Calendar.SECOND);
  }

  public Calendar ToCalendar() {
    return new GregorianCalendar(Year, Month, Day, Hour, Minute, Second);
  }
};
