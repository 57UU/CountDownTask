# CountDownTask
To execulate a task auto after a set time

# Task folder 
C# edition ,which uses async method in order to strengthen the stability.
  ```c#
  var countDownTaskManger=new CountDownTaskManger<T>(double minutes)
  ```
>Method:
  `AddTask()`
  `ClearAll()`
  `Cast(T i)`

# CountDownTask.java
this is java edition,implemented by multi-thread(sxactly only one extra thread,beacuse async method in java is too sick to write).So that may cause Exception by multi-thread assets assign

  ```java
  var countDownTaskManger=new CountDownTaskManger<T>(double minutes)
  ```
  >Method:
  `Add()`
  `Clear()`
  ~~`Cast(T i)`~~
