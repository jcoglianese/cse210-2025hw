using System;

class Program
{
    static void Main(string[] args)
    {
    
       Job job1 = new Job();
       job1._jobTitle = "Software Engineer";

       Job job2 = new Job();
       job2._jobTitle = "Garbage Man";

       Resume myResume = new Resume();
       myResume._name = "Jared Coglianese";
       myResume._jobs.Add(job1);
       myResume._jobs.Add(job2);
       myResume.DisplayResume();

       
       
    }
}