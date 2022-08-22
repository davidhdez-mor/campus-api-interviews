# Campus-API-Interviews
----------------------
CRUD API for interviews, interviewers and interviewees.
The models were created code first, and using EF Core for the migrations.
The API has the next implementations:

## 1. CRUD for Interviews table, the interviews table has a relation many to many (it may contain multiple interviewers and one interviewee)
        The InterviewController has the following endpoints:
            - HTTPGet to get all the interviews and it's information (name, appointment, interviewers and interviewee).
            - HTTPGet to get an specific interview by ID.
            - HTTPPost to post a new interview with it's name, appointment and participants.
            - HTTPPut to update the fields of the interview by a given id.
            - HTTPDelete to delete a row of the interview table by a given id.

## 2. CRUD for Interviewers, the interviewers table has a relation one to many (an interviewer can have multiple interviews)
        The InterviewerController has the following endpoints:
            - HTTPGet to get all the interviewers and it's information (first name, last name, email, birthday and interviews).
            - HTTPGet to get an specific interviewer by ID.
            - HTTPPost to post a new interviewer with it's name, email and birthday.
            - HTTPPut to update the fields of the interview by a given id.
            - HTTPDelete to delete a row of the interviewer table by a given id.
    
## 3. CRUD for Interviewees, the interviewees table has a relation one to one (an interviewee can have one interview)
        The InterviewerController has the following endpoints:
            - HTTPGet to get all the interviewee and it's information (first name, last name, email, birthday).
            - HTTPGet to get an specific interviewee by ID.
            - HTTPPost to post a new interviewee with it's name, email and birthday.
            - HTTPPut to update the fields of the interviewe by a given id.
            - HTTPDelete to delete a row of the interviewee table by a given id.

The project uses AutoMapper, DTO's, IoC, CQRS, Repository pattern, Unit of work pattern (wrapper) and services for the controllers to use.

