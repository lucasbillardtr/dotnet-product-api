/*
Optional<String> mostFrequentProject = companies.stream() // 1. Commence avec un Stream<Company>
   .flatMap(company -> company.getDepartments().stream()) // 2. Passe à un Stream<Department> en aplatissant les listes de départements de chaque entreprise
   .filter(department -> department.getName().equals("Engineering") || department.getName().equals("R&D")) // 3. Filtre pour ne garder que les départements "Engineering" ou "R&D"
   .flatMap(department -> department.getEmployees().stream()) // 4. Passe à un Stream<Employee> en aplatissant les listes d'employés des départements filtrés
   .filter(employee -> employee.getSalary() > 70000 && employee.getStartDate().isAfter(LocalDate.of(2020, 1, 1))) // 5. Filtre les employés selon leur salaire et date d'embauche
   .flatMap(employee -> employee.getProjects().stream() // 6. Passe à un Stream<String> (les noms des projets) en aplatissant les listes de projets de chaque employé filtré
       .filter(project -> project != null && !project.trim().isEmpty())) // 7. S'assure que les noms de projet sont valides (non nuls, non vides)
   .collect(Collectors.groupingBy( // 8. Collecte les résultats dans une Map<String, Long>
       project -> project.toLowerCase(), // Clé de la map : nom du projet en minuscules (pour ignorer la casse)
       Collectors.counting() // Valeur de la map : nombre d'occurrences de ce projet
   ))
   .entrySet().stream() // 9. Convertit l'ensemble des entrées de la map (Map.Entry<String, Long>) en un nouveau Stream
   .max(Map.Entry.<String, Long>comparingByValue() // 10. Trouve l'entrée avec la plus grande valeur (fréquence)
       .thenComparing(Map.Entry.comparingByKey())) // En cas d'égalité de fréquence, compare par la clé (nom du projet, lexicographiquement)
   .map(Map.Entry::getKey); // 11. Extrait le nom du projet (la clé de l'entrée) de l'Optional<Map.Entry> résultant
 */

namespace SandboxConsole;

public record Employee(String Name, int Salary, DateTime StartDate, List<String> Projects) {} 
public record Department(String Name, List<Employee> Employees) {} 
public record Company(String Name, List<Department> Departments) {}


public static class StreamToLinq
{
    public static List<Company> SeedCompany()
    {
        var employees = new List<Employee>
        {
            new Employee("Alice", 50000, DateTime.Now, ["Project1", "Project2", "Project4"]),
            new Employee("Bob", 60000, DateTime.Now.AddYears(-20), ["Project3"]),
            new Employee("Charlie", 70000, DateTime.Now, ["Project4", "Project5"])
        };

        var departments = new List<Department>
        {
            new Department("HR", employees),
            new Department("R&D", employees)
        };

        var companies = new List<Company>
        {
            new Company("TechCorp", departments)
        };
        
        //a new company
        var newEmployees = new List<Employee>
        {
            new Employee("David", 80000, DateTime.Now, ["Project5", "Project4"]),
            new Employee("Eve", 90000, DateTime.Now.AddYears(-20), ["Project4", "Project8"])
        };
        var newDepartments = new List<Department>
        {
            new Department("Engineering", newEmployees),
            new Department("Marketing", newEmployees)
        };
        var newCompany = new Company("FinCorp", newDepartments);
        companies.Add(newCompany);

        return companies;
        
    }
    
    public static string? GetBestProject()
    {
        var companies = SeedCompany();
        return null;
    }
}