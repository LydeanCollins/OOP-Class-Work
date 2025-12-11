using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;
using Week6_DataAccess;


namespace Week6_Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiation of classes (Which we are going to use in both methods)

            AttendanceDbContext db = new AttendanceDbContext(); //database abstraction/represents the database
            StudentsRepository studentsRepository = new StudentsRepository(db); //using this object to manage students'data
            GroupsRepository groupsRepository = new GroupsRepository(db);


            //--------------------------------------------------------------------------



            int mainMenuChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Main menu ============== ");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Units");
                Console.WriteLine("3. Groups");
                Console.WriteLine("4. Attendances");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Input your choice:");
                mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1:
                        StudentsMenu(studentsRepository, groupsRepository);
                        break;

                    case 5:
                        Console.WriteLine("Press any key to terminate the application...");
                        break;
                }

                Console.ReadKey();

            } while (mainMenuChoice != 5);



        }


        static void StudentsMenu(StudentsRepository studentsRepository, GroupsRepository groupsRepository)
        {
            int studentMenuChoice = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(" ============== Student menu ============== ");
                Console.WriteLine("1. List all students");
                Console.WriteLine("2. List students by group");
                Console.WriteLine("3. Search for student");
                Console.WriteLine("4. Add");
                Console.WriteLine("5. Update");
                Console.WriteLine("6. Delete");

                Console.WriteLine("10. Go back to the main menu");
                Console.WriteLine("Input your choice:");
                studentMenuChoice = Convert.ToInt32(Console.ReadLine());

                switch (studentMenuChoice)
                {
                    case 1:

                        var list = studentsRepository.Get();

                        foreach (var student in list)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 2:

                        //ask the user to input the group name
                        Console.WriteLine("Input the group name");
                        string inputGroupName = Console.ReadLine();

                        //var list = studentsRepository.GetByGroupName(...)
                        var list2 = studentsRepository.GetByGroup(inputGroupName);

                        //display the list of students returned from the above line

                        foreach (var student in list2)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 3:
                        //ask the user to input the group name
                        Console.WriteLine("Input keyword");
                        string inputKeyword = Console.ReadLine();

                        //var list = studentsRepository.GetByGroupName(...)
                        var list3 = studentsRepository.Get(inputKeyword);

                        //display the list of students returned from the above line

                        foreach (var student in list3)
                        {
                            Console.WriteLine($"{student.Name}\t\t{student.Surname}\t\t -\t {student.Id}");
                        }

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();


                        break;

                    case 4:
                        Student myNewStudent = new Student();

                        Console.WriteLine("Type in the student's name");
                        myNewStudent.Name = Console.ReadLine();

                        Console.WriteLine("Type in the student's surname");
                        myNewStudent.Surname = Console.ReadLine();

                        Console.WriteLine("Type in the student's idcard");
                        myNewStudent.IdCard = Console.ReadLine();

                        Console.WriteLine("Type in the student's phone");
                        myNewStudent.Phone = Console.ReadLine();

                        Console.WriteLine("Type in the student's email");
                        myNewStudent.Email = Console.ReadLine();


                        Console.WriteLine();
                        Console.WriteLine("Id - Group");
                        Console.WriteLine("-----------------------");
                        foreach (var group in groupsRepository.Get())
                        {
                            Console.WriteLine($"{group.Id} - {group.Name}");
                        }

                        Console.WriteLine("Type in the student's group ID");
                        myNewStudent.GroupFK = Convert.ToInt32(Console.ReadLine());

                        studentsRepository.Add(myNewStudent);

                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;


                    case 5:
                        Console.WriteLine("Input the id of the student that you want to update");
                        int studentIdToUpdate = Convert.ToInt32(Console.ReadLine());

                        //find the student by id
                        var studentToUpdate = studentsRepository.Get().ToList().FirstOrDefault(x => x.Id == studentIdToUpdate);

                        if (studentToUpdate != null)
                        {
                            //display the current information
                            Console.WriteLine("Current information:");
                            Console.WriteLine($"{studentToUpdate.Name}\t\t{studentToUpdate.Surname}\t\t -\t {studentToUpdate.Id}");
                            Console.WriteLine();



                            Console.WriteLine("Type in the new name (press enter to skip)");
                            string newName = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newName))
                            {
                                studentToUpdate.Name = newName;
                            }

                            Console.WriteLine("Type in the new surname (press enter to skip)");
                            string newSurname = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newSurname))
                            {
                                studentToUpdate.Surname = newSurname;
                            }


                            Console.WriteLine("Type in the new idcard (press enter to skip)");
                            string newIdcard = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newIdcard))
                            {
                                studentToUpdate.IdCard = newIdcard;
                            }

                            Console.WriteLine("Type in the new phone (press enter to skip)");
                            string newPhone = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newPhone))
                            {
                                studentToUpdate.Phone = newPhone;
                            }

                            Console.WriteLine("Type in the new email (press enter to skip)");
                            string newEmail = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newEmail))
                            {
                                studentToUpdate.Email = newEmail;
                            }


                            Console.WriteLine();
                            Console.WriteLine("Id - Group");
                            Console.WriteLine("-----------------------");
                            foreach (var group in groupsRepository.Get())
                            {
                                Console.WriteLine($"{group.Id} - {group.Name}");
                            }

                            Console.WriteLine("Type in the new group ID (press enter to skip)");
                            string newGroupId = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(newGroupId))
                            {
                                studentToUpdate.GroupFK = Convert.ToInt32(newGroupId);
                            }



                            //update the student
                            studentsRepository.Update(studentToUpdate);
                        }



                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;

                    case 6:
                        Console.WriteLine("Input the id of the student that you want to delete");
                        int studentIdToDelete = Convert.ToInt32(Console.ReadLine());

                        //find the student by id
                        var studentToDelete = studentsRepository.Get().ToList().FirstOrDefault(x => x.Id == studentIdToDelete);

                        if (studentToDelete != null)
                        {
                            //display the student information
                            Console.WriteLine("Student information:");
                            Console.WriteLine($"{studentToDelete.Name}\t\t{studentToDelete.Surname}\t\t -\t {studentToDelete.Id}");
                            Console.WriteLine();

                            //ask for confirmation
                            Console.WriteLine("Are you sure you want to delete this student? (y/n)");
                            string confirmDelete = Console.ReadLine();
                            if (confirmDelete.ToLower() == "y")
                            {
                                studentsRepository.Delete(studentIdToDelete);
                                Console.WriteLine("Student deleted successfully.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }



                        Console.WriteLine("Click any button to return back to Students Menu...");
                        Console.ReadKey();

                        break;



                    case 10:
                        Console.WriteLine("Press any key to go back to the main menu...");
                        break;
                }



            } while (studentMenuChoice != 10);

        }


    }
}

