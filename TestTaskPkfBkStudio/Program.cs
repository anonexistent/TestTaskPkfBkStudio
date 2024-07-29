using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestTaskPkfBkStudio.Model;

namespace TestTaskPkfBkStudio
{
    internal class Program
    {
        public static TaskTrackerContext db = new();

        public static void InitDatabase()
        {
            Console.WriteLine("do u want initialize database? (y/n)");
            var isIn = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (isIn !='y')
            {
                return;
            }

            try
            {
                db.roles.Add(new Role() { id = Guid.NewGuid(), name = "manager", description = "real manager on the world" });
                db.roles.Add(new Role() { id = Guid.NewGuid(), name = "worker", description = "real worker in a company" });
                db.SaveChanges();

                db.users.Add(new User() { id = Guid.NewGuid(), login = "m", password = "m", role = db.roles.FirstOrDefault(x => x.name == "manager") });
                db.users.Add(new User() { id = Guid.NewGuid(), login = "w", password = "w", role = db.roles.FirstOrDefault(x => x.name == "worker") });
                db.users.Add(new User() { id = Guid.NewGuid(), login = "w2", password = "w2", role = db.roles.FirstOrDefault(x => x.name == "worker") });
                db.SaveChanges();

                //«To do», «In Progress», «Done»
                db.taskStates.Add(new TaskState() { id = Guid.NewGuid(), name = "new" });
                db.taskStates.Add(new TaskState() { id = Guid.NewGuid(), name = "to do" });
                db.taskStates.Add(new TaskState() { id = Guid.NewGuid(), name = "in progress" });
                db.taskStates.Add(new TaskState() { id = Guid.NewGuid(), name = "done" });
                db.SaveChanges();

                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 0", description = "☺", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 1", description = "☻", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 2", description = "♥", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 3", description = "♦", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 4", description = "♣", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 5", description = "♠", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "•", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "◘", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "○", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "◙", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "♂", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "♀", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "♪", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "♫", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.tasks.Add(new Model.Task() { id = Guid.NewGuid(), name = "test task 6", description = "☼", state = db.taskStates.FirstOrDefault(x => x.name == "new") });
                db.SaveChanges();

                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="☺"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="☻"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♥"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♦"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♣"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♠"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="•"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="◘"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="○"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="◙"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♂"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♀"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♪"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="♫"), user=null });
                //db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task=db.tasks.FirstOrDefault(x=>x.name=="☼"), user=null });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintMessage(string m)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(m);

            Console.ResetColor();
        }

        public static void WelcomeMessage()
        {
            PrintMessage(
                "═════════════════════════════════════════════════════════════\n" +
                "\t\t\tTaskTracker v 0.0.1\n" +
                "test users(login:password) :\n" +
                "\tw:w — worker;\n" +
                "\tw2:w2 — worker;\n" +
                "\tm:m — manager ;\n" +
                "═════════════════════════════════════════════════════════════"
                );
        }

        public static User LogIn()
        {
            while (true)
            {
                Console.WriteLine("\tlogin:");
                var login = Console.ReadLine();
                Console.WriteLine("\tpassword:");
                var password = Console.ReadLine();

                if (!string.IsNullOrEmpty(login) & !string.IsNullOrEmpty(password))
                {
                    var potencialUser = db.users.Include(x=>x.role).FirstOrDefault(x => x.login == login);
                    if(potencialUser!=null && potencialUser.password==password)
                    {
                        return potencialUser;
                    }
                }
                Console.WriteLine("something wrong!");
            }
        }

        public static void MainMenu(User u)
        {
            while(true)
            {
                if (u.role.name == "manager")
                {
                    Console.WriteLine("\twhat action need?");
                    Console.WriteLine("new user(u),new work(n), give work (g), exit(x), see tasks(t), see task list(l), see workers(w)");
                    var action = Console.ReadKey();
                    Console.WriteLine();

                    switch (action.KeyChar)
                    {
                        case 'u':
                            var newUser = new User() { id=Guid.NewGuid() };
                            Console.WriteLine("login:");
                            var l = Console.ReadLine();
                            Console.WriteLine("password:");
                            var p = Console.ReadLine();
                            Console.WriteLine("role manager(m)/worker(w):");
                            var r = Console.ReadKey().KeyChar == 'm' ? db.roles.FirstOrDefault(x => x.name == "manager") : db.roles.FirstOrDefault(x => x.name == "worker");

                            newUser.login = l;
                            newUser.password = p;
                            newUser.role = r;

                            db.users.Add(newUser);
                            db.SaveChanges();
                            Console.WriteLine("\nOk\n");

                            break;
                        case 'n':
                            var newTask = new Model.Task() { id=Guid.NewGuid(), state=db.taskStates.FirstOrDefault(x=>x.name=="new")  };
                            Console.WriteLine("name:");
                            var name = Console.ReadLine();
                            Console.WriteLine("decs:");
                            var desc = Console.ReadLine();
                            newTask.name = name; 
                            newTask.description = desc;
                            db.tasks.Add(newTask);
                            db.SaveChanges();
                            Console.WriteLine("Ok\n");
                            break;
                        case 'g':
                            Console.WriteLine("task id:");
                            var t = Guid.Parse(Console.ReadLine().ToString());
                            Console.WriteLine("user id:");
                            var w = Guid.Parse(Console.ReadLine().ToString());

                            var isTask = db.tasks.FirstOrDefault(x => x.id == t);
                            isTask.state = db.taskStates.FirstOrDefault(x => x.name == "to do");
                            var isWorker = db.users.FirstOrDefault(x => x.id == w);

                            db.taskList.Add(new TaskList() { id = Guid.NewGuid(), task = isTask, user = isWorker });
                            db.SaveChanges();
                            Console.WriteLine("Ok\n");
                            try
                            {

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 'x':
                            Console.WriteLine("exit? (y/n)");
                            var isExit = Console.ReadKey();
                            Console.WriteLine();
                            if (isExit.KeyChar == 'y')
                            {
                                return;
                            }
                            else continue;
                            break;
                        case 't':
                            var tasksOut2 = db.tasks.Include(x=>x.state).ToList();

                            foreach (var item in tasksOut2)
                            {
                                Console.WriteLine("task  ├" + item.id + " " + item.name + "|" + item.state.name);
                            }
                            break;
                        case 'l':
                            var tasksOut = db.taskList.Include(x=>x.user).Include(x => x.task).Include(x=>x.task.state).ToList();

                            foreach (var item in tasksOut)
                            {
                                Console.WriteLine("task  ├" + item.task.id + " " + item.task.name + "|" + item.task.state.name);
                                Console.WriteLine("worker├──" + item.user.id + " " + item.user.login);
                            }
                            break;
                        case 'w':
                            var wOut = db.users.Include(x=>x.role).ToList();
                            foreach (var item in wOut)
                            {
                                if (item.role.name == "worker")
                                {
                                    Console.WriteLine("worker├──" + item.id + " " + item.login);
                                }
                            }
                            break;
                        default:
                            break;
                    }


                }
                else if (u.role.name == "worker")
                {
                    Console.WriteLine("\twhat action need?");
                    Console.WriteLine("my tasks(t), edit task(e), exit(x)");
                    var action = Console.ReadKey();
                    Console.WriteLine();

                    switch (action.KeyChar)
                    {
                        case 't':
                            var myTs = db.taskList.Include(x=>x.task).Include(x=>x.task.state).Where(x => x.user == u).ToList();
                            foreach (var item in myTs.Select(x => x.task))
                            {
                                Console.WriteLine("task  ├" + item.id + " " + item.name + "|" + item.state.name);
                            }
                            break;
                        case 'e':
                            Console.WriteLine("task id:");
                            var taskId = Guid.Parse(Console.ReadLine());
                            var t = db.tasks.FirstOrDefault(x=>x.id== taskId);
                            if(t==null)
                            {
                                Console.WriteLine("task not dound");
                            }
                            else
                            {
                                //«To do», «In Progress», «Done»
                                Console.WriteLine("new state \"to do\"(t), \"in progress\"(p), \"done\"(d) or cancel(c)");
                                var newState = Console.ReadKey().KeyChar;
                                switch (newState)
                                {
                                    case 't':
                                        t.state = db.taskStates.FirstOrDefault(x=>x.name== "to do");
                                        break;
                                    case 'p':
                                        t.state = db.taskStates.FirstOrDefault(x => x.name == "in progress");
                                        break;
                                    case 'd':
                                        t.state = db.taskStates.FirstOrDefault(x => x.name == "done");
                                        break;
                                    case 'c':
                                        continue;
                                        break;
                                    default:
                                        break;
                                }
                                Console.WriteLine();
                                Console.WriteLine("Ok\n");
                                db.SaveChanges();
                            }
                            break;
                        case 'x':
                            Console.WriteLine("exit? (y/n)");
                            var isExit = Console.ReadKey();
                            Console.WriteLine();
                            if (isExit.KeyChar == 'y')
                            {
                                return;
                            }
                            else continue;
                            break;
                        default:
                            break;


                    }
                }
            }
        }

        static void Main(string[] args)
        {
            WelcomeMessage();

            InitDatabase();

            var currentUser = LogIn();

            MainMenu(currentUser);

        }
    }
}
