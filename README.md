# Windows Desktop App - Google Forms Replication - Frontend

## Overview

This project replicates the functionality of Google Forms in a Windows Desktop App using Visual Basic and Visual Studio. The application allows users to create and view form submissions, with additional features such as editing and deleting submissions.

## Demo Video

[Watch the demo video](https://drive.google.com/file/d/1yl87NZj6ioXUdPNHUkjgRHtoBxU7qrkJ/view?usp=sharing)

## Features

- Create New Submissions
- View Submissions with navigation (Next, Previous)
- Edit Submissions
- Delete Submissions
- Keyboard shortcuts for form actions
- Styled forms for better UI

## Project Structure

- **MainForm.vb:** Entry point for the desktop app, containing buttons to navigate to the submission forms.
- **CreateSubmissionForm.vb:** Form for creating new submissions.
- **ViewSubmissionsForm.vb:** Form for viewing, editing, and deleting submissions.
- **CreateSubmissionForm.Designer.vb:** Designer file for the Create Submission form.
- **ViewSubmissionsForm.Designer.vb:** Designer file for the View Submissions form.

## Installation and Setup

1. **Install Visual Studio:**
   - Download and install [Visual Studio](https://visualstudio.microsoft.com/) if you don't have it already.

2. **Clone the Repository:**
   - Clone this repository to your local machine using Git.
   ```bash
   git clone <repository_url>
   ```

3. **Open the Project:**
   - Open the project in Visual Studio by selecting the .sln file.

4. **Install Dependencies:**
   -Make sure you have the necessary dependencies installed for your Visual Basic project.

## Forms and Controls

### MainForm
Contains buttons to navigate to the Create Submission and View Submissions forms.

![mainform](https://github.com/sarthakkurothe/slidely_frontend/assets/86231596/ba29cbdc-cd48-4b16-b1e3-857e661ed402)

## CreateSubmissionForm

#### Controls
- TextBox: txtName, txtEmail, txtPhoneNum, txtGithubLink
- TextBox (ReadOnly): txtStopwatch
- Button: btnToggleStopwatch, btnSubmit
Keyboard Shortcuts
- Ctrl + T: Toggle Stopwatch
- Ctrl + S: Submit Form

## ViewSubmissionsForm

#### Controls
- TextBox: txtName, txtEmail, txtPhoneNum, txtGithubLink
- Label: lblStopwatch
- Button: btnNext, btnPrevious, btnEdit, btnDelete
Keyboard Shortcuts
- Ctrl + N: Next Submission
- Ctrl + P: Previous Submission

## Styling Forms
To style the forms, you can use the properties window in Visual Studio to set properties like BackColor, Font, ForeColor, etc., for each control. You can also use custom styles and themes as needed.

## Running the Application

- Ensure Backend is Running:

Make sure the backend server is running on http://localhost:3000.

- Run the Desktop App:

In Visual Studio, set the startup project to your solution and run the application.


