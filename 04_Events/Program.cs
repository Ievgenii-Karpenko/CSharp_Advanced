using System;

namespace _04_Events
{
    delegate void UI(object sender, EventArgs eventArgs);

    class MyEvent
    {
        public event UI UserEvent;

        // Method to invoke event
        public void OnUserEvent()
        {
            //if(UserEvent != null)
            //{ 
                UserEvent.Invoke();
            //}
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
            //evt.UserEvent -= user1.UserInfoHandler;

            //
            //...
            // Invoke event

            evt.OnUserEvent();

            Console.ReadLine();
        }
    }

    class MyCustomEvent
    {
        UI[] evnt = new UI[5];

        public event UI UserEvent
        {
            // Using of accessors
            add
            {
                evnt[1] = value;
            }

            remove
            {
                evnt[1] = null;
            }
        }

        public void OnUserEvent()
        {
            evnt[1]();
        }
    }
}