namespace API;

public interface IMockDb
{
    public ICollection<Animal> GetAllAnimals();
    public Animal? PickAnimal(int id);

    public Animal? RemoveAnimal(int  id);
    public bool AddAnimal(Animal animal);
    public ICollection<Vet> GetAllVets();

    public bool AddNewVisit(Vet newVisit);

    public ICollection<Vet> GetVisitsForAnimal(int animalId);

    public Animal? EditAnimal(int idEditetAnimal, Animal newanimal);
}
public class MockDb : IMockDb
{
    private ICollection<Animal> _animal;
    private ICollection<Vet> _vets;

    public MockDb()
    {
        _animal = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                imie = "Puszek",
                kategoria = "kot",
                masa = 13.4,
                kolorSiersci = "Rudy"
            },
            new Animal
            {
                Id = 2,
                imie = "Osiol",
                kategoria = "Koniowate",
                masa = 43.32,
                kolorSiersci = "Szary"
            }
        };

        _vets = new List<Vet>
        {
            new Vet
            {
                date = DateTime.Now,
                animal = _animal.First(),
                opisWizyty = "Strzyrzenie",
                cena = 30.23
            },
            
            new Vet
            {
            date = DateTime.Now,
            animal = _animal.First(),
            opisWizyty = "Leczenie ",
            cena = 3000
        },
            new Vet
            {
                date = DateTime.Now,
                animal = PickAnimal(2),
                opisWizyty = "Antybiotyk",
                cena = 321
            }
        };
    }

 

    public Animal? PickAnimal(int id)
    {
        return _animal.FirstOrDefault(e => e.Id == id);
    }

    public Animal? RemoveAnimal(int id)
    {
        var animalToDeletle = _animal.FirstOrDefault(animal => animal.Id == id);
        if(animalToDeletle is null) return null;
        _animal.Remove(animalToDeletle);
        return animalToDeletle;

    }


    public ICollection<Animal> GetAllAnimals()
    {
        return _animal;
    }

    public bool AddAnimal(Animal animal)
    {
        _animal.Add(animal);
        return true;
    }

    public ICollection<Vet> GetAllVets()
    {
        return _vets;
    }

    public bool AddNewVisit(Vet newVisit)
    {
        if (newVisit.animal == null || _animal.FirstOrDefault(a => a.Id == newVisit.animal.Id) == null)
        {
            return false; 
        }
        _vets.Add(newVisit);
        return true;
    }
    public ICollection<Vet> GetVisitsForAnimal(int animalId)
    {
        return _vets.Where(vet => vet.animal.Id == animalId).ToList();
    }


    public Animal? EditAnimal(int idEditetAnimal,Animal newanimal)
    {
        var animalToEdit = _animal.FirstOrDefault(animal => animal.Id == idEditetAnimal);
        if(animalToEdit is null) return null;
        animalToEdit.Id = newanimal.Id;
        animalToEdit.imie = newanimal.imie;
        animalToEdit.kategoria = newanimal.kategoria;
        animalToEdit.masa = newanimal.masa;
        animalToEdit.kolorSiersci = newanimal.kolorSiersci;

        return animalToEdit;
    }
}