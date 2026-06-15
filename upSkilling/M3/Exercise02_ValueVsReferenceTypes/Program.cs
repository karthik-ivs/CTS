using System;

class Student{
    public string Name;
}

class Program{
    static void ChangeInt(int x){
        x = 100;
    }

    static void ChangeStudent(Student st){
        st.Name = "IVS";
    }

    static void Main(){
        int x = 10;

        Student st = new Student();
        st.Name = "Karthik";

        Console.WriteLine("Before :"+ x);
        ChangeInt(x);
        Console.WriteLine("After :"+ x);

        Console.WriteLine("Before :"+ st.Name);
        ChangeStudent(st);
        Console.WriteLine("After :"+ st.Name);
    }
}