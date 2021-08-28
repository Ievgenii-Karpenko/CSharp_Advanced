using System;

namespace _04_Events
{
    delegate void UI();

    class MyEvent
    {
        public event UI UserEvent;

        // Method to invoke event
        public void OnUserEvent()
        {
            UserEvent?.Invoke();
        }
    }

    class UserInfo
    {
        string uiName, uiFamily;
        int uiAge;

        public UserInfo(string name, string family, int age)
        {
            Name = name;
            FamilyName = family;
            Age = age;
        }

        public string Name
        {
            set => uiName = value;
            get => uiName;
        }
        public string FamilyName
        {
            set => uiFamily = value;
            get => uiFamily;
        }
        public int Age { 
            set => uiAge = value; 
            get => uiAge; 
        }

        // Event handler
        public void UserInfoHandler()
        {
            Console.WriteLine("Event called!\n");
            Console.WriteLine($"Name: {Name}\tFamily Name: {FamilyName}\nAge: {Age}");
        }
    }

    class Program
    {
        static void Main()
        {
            //MyEvent evt = new MyEvent();
            MyCustomEvent evt = new MyCustomEvent();
            UserInfo user1 = new UserInfo("Alex", "Smith", 26);

            Console.WriteLine(user1.Name ?? "asd");
            //user1.Name != null ? user1.Name : "asd"

            // Adding of event handler
            evt.UserEvent += user1.UserInfoHandler;
            evt.UserEvent -= user1.UserInfoHandler;

            // Invoke event
            evt.OnUserEvent();

            Console.ReadLine();
        }
    }

    class MyCustomEvent
    {
        UI[] evnt = new UI[5];
        int index = 0;

        public event UI UserEvent
        {
            // Using of accessors
            add
            {
                Console.WriteLine("....");
                evnt[index] = value;
                index++;
            }

            remove
            {
                evnt[--index] = null;
            }
        }

        public void OnUserEvent()
        {
            evnt[index]?.Invoke();
        }
    }
}