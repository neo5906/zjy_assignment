using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace assignment4_program2
{
    public class AlarmClock
    {
        private Timer timer;
        private DateTime alarmTime;
        private bool isAlarmSet;

        public event Action Tick;
        public event Action Alarm;

        public AlarmClock()
        {
            timer = new Timer(1000); // 每秒触发一次  
            timer.Elapsed += OnTick;
        }

        public void Start()
        {
            timer.Start();
            Console.WriteLine("闹钟启动");
        }

        public void Stop()
        {
            timer.Stop();
            Console.WriteLine("闹钟停止");
        }

        public void SetAlarm(DateTime time)
        {
            alarmTime = time;
            isAlarmSet = true;
            Console.WriteLine($"闹钟设置为 {alarmTime.ToString("HH:mm:ss")}");
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Tick?.Invoke(); // 触发 Tick 事件  
            Console.WriteLine("嘀嗒...");

            if (isAlarmSet && DateTime.Now >= alarmTime)
            {
                Alarm?.Invoke(); 
                isAlarmSet = false; 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();          
            alarmClock.Alarm += () => { Console.WriteLine("闹钟响铃！时间到！"); };
            alarmClock.Start();
            alarmClock.SetAlarm(DateTime.Now.AddSeconds(5));
            Console.WriteLine("按任意键停止闹钟");
            Console.ReadKey();
            alarmClock.Stop();
        }
    }
}
