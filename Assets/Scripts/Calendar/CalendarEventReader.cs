using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CalendarEventReader", menuName = "Events/CalendarEventReader")]
public class CalendarEventReader : ScriptableObject
{
   public event UnityAction<Calendar> calendarChanged;

   public void OnCalendarChanged(Calendar calendar)
    {
        calendarChanged.Invoke(calendar);
    }

}
