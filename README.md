# Habit Buddies

## **Overview**

Habit Buddies is a web application created for people who love to push themselves into becoming the best version of themselves. It is estimated that the average time for one person to acquire a habit is 28 days. Our app gives you the opportunity to create habits and stick to them. During the process, you can have fun by tracking your progress, gaining XP and achieving high ranks! And the best thing about it is that you will be able to do this with friends - in this app you can not only see your personal habit list but also the habit list of your friends and get inspired by their ideas! 

## **Architecture**

This app uses MVC (Model-View-Controller) architecture which separates the web app into three main components - Models, Views and Controller. We have put our data in the data folder in a subfolder called **Entities** because it is a convention to do so. 

![Untitled](https://user-images.githubusercontent.com/71072498/230667638-39de6f29-0524-4f47-9d9e-2795c442552b.png)  ![Untitled](https://user-images.githubusercontent.com/71072498/230667804-a59c2a2c-9d08-4061-ab8b-e8d7a7a9de95.png) ![Untitled](https://user-images.githubusercontent.com/71072498/230667751-bc4d9590-6084-4783-bad1-bcf44973020a.png)


In the following screenshots you can see the main components of our web app:

The **Data Folder** ⇒ where the entities are stored, the connection between the entities are established, the needed migrations are applied and the Data Seeder put records in the database when the entity tables in the database are empty.

Entities: Habit, Notification, User, and UserFriendship which describe the main data sections.

**The Controllers folder** ⇒ where the business logic is made and the magic happens

We have a controller for every function in our web app: HabitsController, NotificationController, HomeController, UserFriendshipController and OneSignalNotificationsController

**The Views Folder** ⇒ The **Views** represent the user interface of the application.

In each View, there are files responsible for showing accurate data and design for each CRUD operation.

## **Functionality**

**This web app includes the following features:**

- Create an Individual account with an email and password
- Create a Habit
- Adds Habit to Habit list
- Edit Habit
- Delete Habit
- Create personalized Notifications for each Habit ( you can add up to 3 notifications for one habit)
- Create new Notifications for chosen habit
- Add Notification to List of Notifications
- Edit Notification
- Delete Notification
- Add a friend to Friend List via his UserId
- access Friend’s List of Habits
- Remove Friend from Friend List

**Additional features:** 

- Add habits to Calendar
- view Habit Details when you click on the Habit on the calendar
- Track your progress by the progress bar in each Habit’s details
- Click the “Mark as completed” Button in Habit’s details so you can track your progress by the progress bar, this way you can see how close you are to your goal
- When Completing a full Habit after the 28 days have passed you may click the official “Completed” button in your Habit’s details to officially mark it as finished! You also get your XP like that and may even raise your Rank!
- You can view your Rank and XP in the navbar next to your account
- You can allow Notifications being sent to you from our web app!

## How to Run the Project

### Follow these steps:

1. Clone the project to your local computer
2. Open the project folder using Visual Studio 2022
3. Build the project
4. Run the project by pressing F5 or clicking on the green "Run" button in Visual Studio


## **Usage**

**Create an account:** 

![Untitled](https://user-images.githubusercontent.com/71072498/230668180-82f5e253-f362-4dfc-8007-ff63632a2b17.png)

**This is your Main page or the Home page:**

![Untitled](https://user-images.githubusercontent.com/71072498/230668241-80ddbd07-c8a7-492e-8b0c-212b27821ce3.png)

From the **“CREATE HABIT”** button you can create a New habit and its related Notifications

From the **“CREATE FRIEND”** button you can add a new friend via his **UserId**

In the **calendar**, under them, you can see all of your current habits (beginning: Start Date and ending: EndDate)

When you **press on one of the habits**: 

![Untitled](https://user-images.githubusercontent.com/71072498/230668328-4ef7c2a4-5444-4d05-9f47-04821ad22f96.png)

 On the page **appears a pop up** with all the **information for the clicked habit**

Now let’s look at the navbar. There are links to the **Home Page**, **Habits Page**, **Friends Page** and **Notifications Page**

### **Habits:**

![Untitled](https://user-images.githubusercontent.com/71072498/230668424-225f3b71-0274-4afa-a352-d690d22e72b3.png)

This is the Habit Index Page ⇒ your Habits List 

The **“Create New Habit”** Button Creates a New habit and adds to the Habit List

With ✎  you can **edit** the habit

With ℹ️  you can **see the details** of the habit

With 🗑️ you can **delete** the habit

When you click ℹ️ icon for the details of the page you can see all the details about the habit but also one **“Complete for the day”** button and progress bar under it. This button appears every day in each Habit’s details page and helps you track your progress with progress bar. This is how it looks like:

![Untitled](https://user-images.githubusercontent.com/71072498/230668485-959a493e-ae53-4f3c-84af-dfa5a6839804.png)
And when clicked the progress for the day is added to your progress bar and the **“Complete for the day”** button will appear again tomorrow:

![Untitled](https://user-images.githubusercontent.com/71072498/230668589-f091c7d6-f1c7-442c-9c23-b1ef41de489f.png)
When 28 days have passed since the creation of the Habit  you will see the **“Mark as Completed”** button in Habit’s details which when clicked will actually add your habit to finished habits and colour its row in minty-green as an indicator that it is finished:

 

![Untitled](https://user-images.githubusercontent.com/71072498/230668663-55f1b4f1-37ff-4f39-bafc-3f1dec0b5a1f.png)
Also, this action will automatically **add XP** and you may even raise your **Rank:** 

![Untitled](https://user-images.githubusercontent.com/71072498/230668737-95550fb6-ac3e-43fb-9472-f994dd4afa96.png)
### **Notifications:**

![Untitled](https://user-images.githubusercontent.com/71072498/230668822-f88b450e-8840-4125-90f8-be86b13e3641.png)

This is the Notification Index Page ⇒ your Notifications List 

The **“Create New Notification”** Button Creates a New Notification and adds it to the Notification List

With ✎  you can **edit** the Notification

With ℹ️  you can **see the details** of the Notification

With 🗑️ you can **delete** the Notification

### **Friends:**

![Untitled](https://user-images.githubusercontent.com/71072498/230668897-23ca1c64-c8fb-4980-b396-5c9e5ae2d7a9.png)

This is the Friends Index Page ⇒ your Friends List 

The **“ADD A FRIEND”** Button adds an existing user to your Friends List

With ❗  you can **see the Habit List** of your friend

With 🗑️ you can **remove** the user from your Friend List

## **Contact Information**

Our team consists of: 

**Polina Staneva** ⇒ email: polina.staneva@yahoo.com

**Kosta Ilev** ⇒ kosta.ilev@gmail.com

**Ekaterina Staneva** ⇒ ekaterina18.st@gmail.com

This project was created by team **“Power Trio Web Cats”**

![Untitled](https://user-images.githubusercontent.com/71072498/230668955-9ec8a315-2075-41a6-889d-f9da99b73ec9.png)
