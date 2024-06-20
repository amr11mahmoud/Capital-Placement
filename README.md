You can test the endpoints using swagger UI
![Screenshot 2024-06-20 194549](https://github.com/amr11mahmoud/Capital-Placement/assets/53308603/526d554e-d5e8-41aa-963a-0eb9121eca4c)
simple docs:
1- each program consist of static questions (personal info) and dynamic (custom questions)
2- after program creation there is an endpoint to delete program custom question using its id and another one to update
3- each program holds list of applications you can fetch them using getAll endpoint under api/programs/{program_id}/applications
4- update application is not implemented (time constrain)
