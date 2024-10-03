# Temari - E-Learning Platform

**Temari**, amharic for student, is an e-learning web application built using **ASP.NET MVC**. The platform provides a user-friendly environment for both administrators and students. It is designed to facilitate the creation and management of educational content, as well as to provide students with access to courses, subcourses, and educational concepts for free.

## Project Overview

Temari features two types of user accounts:
1. **Admin**: Can create and manage courses, subcourses, and basic educational concepts.
2. **Student**: Can sign up, log in, and access courses and subcourses for free.

### Admin Features

- **Dashboard Overview**: Admins have a comprehensive view of the platform's status upon login, including the number of students, courses, subcourses, and major concepts.
- **Course Management**:
  - Admins can create courses and subcourses, and assign details such as:
    - Title
    - Course description
    - Duration
    - Picture
    - Course materials
  - Admins can also create basic concepts that are accessible to anyone.
- **Student Information**: Admins can view basic student details.
- **Calendar**: A calendar feature on the admin dashboard allows for adding necessary course information.

### Student Features

- **Signup and Login**: Students can register using their email and password. A password strength checker ensures secure password creation.
- **Home Page**: After logging in, students are greeted with:
  - A **calendar** for managing their tasks.
  - A **student guide query** that integrates with multiple websites to provide help with specific academic issues.
- **Access to Courses**: Students can browse through courses, subcourses, and educational concepts for free.
- **Account Management**: Students can manage their personal information, update account details, and log out of the platform.
- **Donation Feature**: All courses are provided for free but if a student wants to donate, we have integrated the chapa api to donate easily.

## Features Overview

- **User Roles**:
  - **Admin**: Manages the platform by creating and organizing courses and subcourses, and viewing student information.
  - **Student**: Can sign up, log in, access educational content, and manage personal information.
  
- **Course Management**: Admins have the ability to:
  - Add and manage courses, subcourses, and educational concepts.
  - Upload course materials and set course-specific details such as title, duration, and description.

- **Calendar Integration**: Both admin and students have access to a calendar feature for scheduling and managing tasks.

- **Student Guide Query**: Provides integrated support for students by offering resources from multiple websites based on their academic needs.

## Usage

1. **Admin**:
   - Log in to the platform using admin credentials.
   - View the dashboard with key statistics (students, courses, subcourses, concepts).
   - Create and manage courses, subcourses, and basic concepts.
   - Add relevant information to the platform calendar.
   - View student details when needed.

2. **Student**:
   - Sign up with an email and password.
   - Log in to the system with secure password validation.
   - Access free educational content (courses, subcourses, concepts).
   - Use the calendar to organize tasks and deadlines.
   - Use the student guide query for help with specific questions or challenges.
   - Manage your account and personal details.
   - Log out when finished.

## Technology Stack

- **ASP.NET MVC**
- **CSHTML**
- **CSS** and **JavaScript** for front-end interactions.
- **SQL** for database management.
