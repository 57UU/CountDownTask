using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tasks
{
    public class CountDownTaskManager
    {
        int time;
        public CountDownTaskManager(float time)
        {
            this.time = (Int32)(time * 60 * 1000);
        }
        Group<CountDownTask> tasks =new();
        public void AddTask(ThreadStart runable)
        {
            CountDownTask countDownTask = new(runable);
            var task = StartTask(countDownTask);
            tasks.Add(countDownTask);
            task.ContinueWith((e) =>
            {
                tasks.Remove(countDownTask);
            });
        }
        private class CountDownTask
        {
            public ThreadStart runable;
            public bool isCancel=false;
            public CountDownTask(ThreadStart runable)
            {
                this.runable = runable;
            }
        }
        private async Task StartTask(CountDownTask task)
        {
            await Task.Delay(time);
            if (task.isCancel)
            {
                return;
            }
            task.runable();
        }
        public void ClearAll()
        {
            tasks.Cast((i) =>
            {
                i.isCancel = true;
            });
        }

    }
}
