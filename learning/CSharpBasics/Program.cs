/*Console.WriteLine("Welcome to TripWeave!");

Console.WriteLine("================================");
Console.WriteLine("          TripWeave          ");
Console.WriteLine("================================");

Console.WriteLine("Your intelligent travel companion.");
Console.WriteLine("Enter destination: ");
string destination = Console.ReadLine()!;

int travelers;
while(true){
    Console.WriteLine("Enter number of travelers: ");
    if(int.TryParse(Console.ReadLine()!, out travelers) 
    && (travelers > 0)){
        Console.WriteLine($"you entered {travelers} travelers");
        break;
    }
    Console.WriteLine("Please enter a valid whole number greater than zero.");
}


int days;
while(true){
    Console.WriteLine("Enter number of days: ");
    if(int.TryParse(Console.ReadLine()!, out days) && days > 0){
        Console.WriteLine($"you entered {days} days");
        break;
    }
    Console.WriteLine("Please enter a valid whole number greater than zero.");
}
 

decimal accommodationCost;
while(true){
    Console.WriteLine("Enter accommodation Cost: ");
    if(decimal.TryParse(Console.ReadLine()!, out accommodationCost) && accommodationCost > 0){
        Console.WriteLine($"you entered {accommodationCost:N2}");
        break;
    }
    Console.WriteLine("Please enter a valid decimal number greater than zero.");
}


decimal foodCost;
while(true){
    Console.WriteLine("Enter food Cost: ");
    if(decimal.TryParse(Console.ReadLine()!, out foodCost) && foodCost > 0){
        Console.WriteLine($"you entered {foodCost:N2}");
        break;
    }
    Console.WriteLine("Please enter a valid decimal number greater than zero.");
}


decimal transportationCost;
while(true){
    Console.WriteLine("Enter transportation Cost: ");
    if(decimal.TryParse(Console.ReadLine()!, out transportationCost) && transportationCost > 0){
        Console.WriteLine($"you entered {transportationCost:N2}");
        break;
    }
    Console.WriteLine("Please enter a valid decimal number greater than zero.");
}


decimal activitiesCost;
while(true){
    Console.WriteLine("Enter activities Cost: ");
    if(decimal.TryParse(Console.ReadLine()!, out activitiesCost) && activitiesCost > 0){
        Console.WriteLine($"you entered {activitiesCost:N2}");
        break;
    }
    Console.WriteLine("Please enter a valid decimal number greater than zero.");
}


decimal miscellaneousCost;
while(true){
    Console.WriteLine("Enter miscellaneous Cost: ");
    if(decimal.TryParse(Console.ReadLine()!, out miscellaneousCost) && miscellaneousCost > 0){
        Console.WriteLine($"you entered {miscellaneousCost:N2}");
        break;
    }
    Console.WriteLine("Please enter a valid decimal number greater than zero.");
}


decimal totalCost = accommodationCost + foodCost + transportationCost + activitiesCost + miscellaneousCost;


Console.WriteLine("========Trip Summary========");
Console.WriteLine($"Destination: {destination}");
Console.WriteLine($"Travelers: {travelers}");
Console.WriteLine($"Trip Duration:  {days} days");
Console.WriteLine($"Total Cost: {totalCost:N2}");
Console.WriteLine($"Cost Per Person: {totalCost / travelers:N2}"); 
Console.WriteLine($"Cost Per Day: {totalCost / days:N2}");

Console.WriteLine("=======Recommanded Places=======");

string[] recommandedPlaces = new string[] {
    "Ella",
    "Nuwara Eliya",
    "Kandy",
    "Sigiriya",
    "Galle",
}

decimal activityCost = new decimal[] {
    1000.00m,
    1500.00m,
    2000.00m,
    2500.00m,
    3000.00m
};

for (int i=0; i < recommandedPlaces.Length; i++)
{
    Console.WriteLine($"{i + 1}. {recommandedPlaces[i]} - {activityCost[i]:N2}");
}

Console.WriteLine("Let's Plan your journey!");*/

/*List<string> itinerary = new List<string>();
Console.WriteLine("How many places do you want to add?");
int n = int.Parse(Console.ReadLine()!);
for(int i=0; i<n; i++){
    Console.WriteLine($"Enter place {i+1}: ");
    string place = Console.ReadLine()!;
    itinerary.Add(place);
}

Console.WriteLine("======== Your Itinerary ========");
for(int i=0; i<itinerary.Count; i++){
    Console.WriteLine($"{i+1}. {itinerary[i]} ");
}

Console.WriteLine("Do you want to remove a place? (y/n)");
string response = Console.ReadLine()!;
if(response.ToLower() == "y"){
    Console.WriteLine("Enter the place to remove: ");
    string placeToRemove = Console.ReadLine()!;
    if(itinerary.Remove(placeToRemove)){
        Console.WriteLine($"{placeToRemove} has been removed from your itinerary.");
    } else {
        Console.WriteLine($"{placeToRemove} was not found in your itinerary.");
    }
}
Console.WriteLine("======== Updated Itinerary ========");
for(int i=0; i<itinerary.Count; i++){
    Console.WriteLine($"{i+1}. {itinerary[i]} ");
}
*/
/*List<string> destination = new List<string>();
Console.WriteLine("How many places do you want to add?");
int n = int.Parse(Console.ReadLine()!);
for(int i=0; i<n; i++){
    Console.WriteLine($"Enter place {i+1}: ");
    string place = Console.ReadLine()!;
    destination.Add(place);
}

Console.WriteLine("Enter no of travelers: ");
int travelers = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter no of days: ");
int days = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter accommodation cost: ");
decimal accommodationCost = decimal.Parse(Console.ReadLine()!);

Console.WriteLine("Enter food cost: ");
decimal foodCost = decimal.Parse(Console.ReadLine()!);    

Console.WriteLine("Enter transportation cost: ");
decimal transportationCost = decimal.Parse(Console.ReadLine()!);

Console.WriteLine("Enter activities cost: ");
decimal activitiesCost = decimal.Parse(Console.ReadLine()!);

Console.WriteLine("Enter miscellaneous cost: ");
decimal miscellaneousCost = decimal.Parse(Console.ReadLine()!);

static decimal CalculateTotalCost(
    decimal accommodationCost,
    decimal foodCost,
    decimal transportationCost,
    decimal activitiesCost,
    decimal miscellaneousCost
){
       return accommodationCost + foodCost + transportationCost + activitiesCost + miscellaneousCost;
}

decimal totalCost = CalculateTotalCost(accommodationCost, foodCost, transportationCost, activitiesCost, miscellaneousCost);

static decimal CalculateCostPerPerson(decimal totalCost, int travelers){
    return totalCost / travelers;
}

decimal costPerPerson = CalculateCostPerPerson(totalCost, travelers);

static void DisplayTripSummary(
    List<string> destination,
    int travelers,
    int days,
    decimal totalCost,
    decimal costPerPerson
){
    Console.WriteLine("========Trip Summary========");
    Console.WriteLine($"Destination: {string.Join(", ", destination)}");
    Console.WriteLine($"Travelers: {travelers}");
    Console.WriteLine($"Trip Duration:  {days} days");
    Console.WriteLine($"Total Cost: {totalCost:N2}");
    Console.WriteLine($"Cost Per Person: {costPerPerson:N2}"); 
    Console.WriteLine($"Cost Per Day: {totalCost / days:N2}");
}

DisplayTripSummary(destination, travelers, days, totalCost, costPerPerson);
*/
/*
Trip trip1 = new Trip("Ella", 2, 5, 10000.00m);
Trip trip2 = new Trip("Kandy", 3, 6, 70000.00m);
Trip trip3 = new Trip("Matara", 2, 5, 40000.00m);

/*trip.Destination = "Ella";
trip.Travelers = 2;
trip.Days = 5;
trip.Budget = 10000.00m;*/
/*
Console.WriteLine("========Trip1 Summary========");

Console.WriteLine($"Destination: {trip1.Destination}");
Console.WriteLine($"Travelers: {trip1.Travelers}");
Console.WriteLine($"Trip Duration: {trip1.Days} days");
Console.WriteLine($"Budget: {trip1.Budget:N2}");

Console.WriteLine("========Trip2 Summary========");

Console.WriteLine($"Destination: {trip2.Destination}");
Console.WriteLine($"Travelers: {trip2.Travelers}");
Console.WriteLine($"Trip Duration: {trip2.Days} days");
Console.WriteLine($"Budget: {trip2.Budget:N2}");

Console.WriteLine("========Trip3 Summary========");

Console.WriteLine($"Destination: {trip3.Destination}");
Console.WriteLine($"Travelers: {trip3.Travelers}");
Console.WriteLine($"Trip Duration: {trip3.Days} days");
Console.WriteLine($"Budget: {trip3.Budget:N2}");


class Trip
{
    public string Destination { get; set; }

    public int Travelers { get; set; }

    public int Days { get; set; }

    public decimal Budget { get; set; }

    public Trip(string Destination, int Travelers, int Days, decimal Budget)
    {
        this.Destination = Destination;
        this.Travelers = Travelers;
        this.Days = Days;
        this.Budget = Budget;
    }
}*/

//IMessageService sender = new EmailSender();
//IMessageService sender = new SmsSender();

//sender.sendMessage();
//smsSender.sendMessage();
/*
class EmailSender : IMessageService{
    public void sendMessage(){
        Console.WriteLine("Sending email...");
    }
}

class SmsSender : IMessageService{
    public void sendMessage(){
        Console.WriteLine("Sending SMS...");
    }
}

interface IMessageService{
    void sendMessage();
}*/
/*
IWeatherService weatherService = new MockWeatherService();
string weather = weatherService.GetWeather();
Console.WriteLine($"Current Weather: {weather}");


class MockWeatherService : IWeatherService{
    public string GetWeather(){
        return "Sunny, 28°C";
    }
}

interface IWeatherService{
    string GetWeather();
}*/
/*
Trip trip = new Trip("Ella", 2);
trip.SetBudget(-10000.00m);

Console.WriteLine($"Destination: {trip.Destination}");
Console.WriteLine($"Travelers: {trip.Travelers}");
Console.WriteLine($"Budget: {trip.Budget:N2}");

SoloTrip trip2 = new SoloTrip();
trip2.Destination = "Kandy";
trip2.Travelers = 1;
trip2.ShowDestination();

class Trip{
    public string Destination { get; private set; }

    public void showDestination(){
        Console.WriteLine($"Destination: {Destination}");
    }
    public int Travelers { get; private set; }
    public decimal Budget { get; private set; }

    public Trip (string destination, int travelers){
        Destination = destination;
        Travelers = travelers;
        //Budget = 0;
    }

    public void SetBudget(decimal amount){
        if (amount >= 0 ){
            Budget = amount;
        }
    }
}

class SoloTrip : Trip{
    public void ShowTripType(){
        Console.WriteLine("This is a solo trip.");
    }
}*/
/*
Trip solo = new SoloTrip();
solo.ShowBasicInfo();
((SoloTrip)solo).ShowTripType();

Trip family = new FamilyTrip();
family.ShowBasicInfo();
((FamilyTrip)family).ShowTripType();


class Trip{
    public string Destination {get; set;}
    public int Days{get; set;}

    public void ShowBasicInfo(){
        Console.WriteLine($"Destination: {Destination}");
        Console.WriteLine($"Days: {Days}");
    }
}

class SoloTrip : Trip{
    public void ShowTripType(){
        Console.WriteLine("This is a solo trip.");
    }
}

class FamilyTrip : Trip{
    public void ShowTripType(){
        Console.WriteLine("This is a family trip.");
    }
}*/

/*
List<Trip> trips = new List<Trip>
{
    new Trip("Ella", 5, 50000),
    new Trip("Kandy", 3, 30000),
    new Trip("Tokyo", 10, 400000),
    new Trip("Bali", 7, 250000),
    new Trip("Galle", 2, 25000),
    new Trip("Nuwara Eliya", 6, 200000)
};

int tripCount = trips.Count();
Console.WriteLine($"Total trips available: {tripCount}");

decimal totalBudegt = trips.Sum(trip => trip.Budget);
Console.WriteLine($"Total budget for all trips: {totalBudegt:N2}");

decimal averageBudget = trips.Average(trips => trips.Budget);
Console.WriteLine($"Average budget for all trips: {averageBudget:N2}");

decimal minimumBudget = trips.Min(trip => trip.Budget);
Console.WriteLine($"Minimum budget for all trips: {minimumBudget:N2}");

decimal maximumBudget = trips.Max(trip => trip.Budget);
Console.WriteLine($"Maximum budget for all trips: {maximumBudget:N2}");


Console.WriteLine("===== TripWeave Statistics =====");
Console.WriteLine($"Total trips available: {tripCount}");
Console.WriteLine($"Total budget for all trips: {totalBudegt:N2}");
Console.WriteLine($"Average budget for all trips: {averageBudget:N2}");
Console.WriteLine($"Minimum budget for all trips: {minimumBudget:N2}");
Console.WriteLine($"Maximum budget for all trips: {maximumBudget:N2}");


Console.WriteLine("Enter destination to search: ");
string searchDestination = Console.ReadLine()!;

var foundTrips = trips.FirstOrDefault(trip => trip.Destination.Equals(searchDestination, StringComparison.OrdinalIgnoreCase));

if (foundTrips != null)
{
    Console.WriteLine($"Found trip: {foundTrips.Destination}");
    Console.WriteLine("========Trip found========");
    Console.WriteLine($"Destination: {foundTrips.Destination}");
    Console.WriteLine($"Days: {foundTrips.Days}");
    Console.WriteLine($"Budget: {foundTrips.Budget.ToString("N2", System.Globalization.CultureInfo.InvariantCulture)}");
}
else
{
    Console.WriteLine("Trip not found.");
}

var matchingTrips = trips.Where(trip => trip.Days >= 5 && trip.Budget <= 200000);
var sortedTrips = trips.OrderBy(trip => trip.Budget);
foreach (Trip trip in sortedTrips){
    Console.WriteLine($"{trip.Destination} - {trip.Budget:N2}");
}

var tripsByBudgetDescending = trips.OrderByDescending(
    trip => trip.Budget
);
foreach (Trip trip in tripsByBudgetDescending){
    Console.WriteLine($"{trip.Destination} - {trip.Budget:N2}");
}

var tripsByDaysThenBudget = trips
    .OrderBy(trip => trip.Days)
    .ThenByDescending(trip => trip.Budget);

Console.WriteLine("===== Cheapest Trips =====");
foreach (Trip trip in tripsByDaysThenBudget){
    Console.WriteLine($"Destination: {trip.Destination}");
    Console.WriteLine($"Days: {trip.Days}");
    Console.WriteLine($"Budget: {trip.Budget.ToString("N2", System.Globalization.CultureInfo.InvariantCulture)}");
    Console.WriteLine();
}


Console.WriteLine("===== Matching Trips =====");
Console.WriteLine();

foreach (Trip trip in matchingTrips){
    Console.WriteLine($"Destination: {trip.Destination}");
    Console.WriteLine($"Days: {trip.Days}");
    Console.WriteLine($"Budget: {trip.Budget.ToString("N2", System.Globalization.CultureInfo.InvariantCulture)}");
    Console.WriteLine();
}


// Task 1: Select only destination names.
var destinations = trips.Select(trip => trip.Destination);

Console.WriteLine("===== Destinations =====");
foreach (string destination in destinations)
{
    Console.WriteLine(destination);
}
Console.WriteLine();

// Task 2: Transform each trip into a formatted summary.
var summaries = trips.Select(trip =>
    $"{trip.Destination} - {trip.Days} days - Rs. {trip.Budget.ToString("N2", System.Globalization.CultureInfo.InvariantCulture)}");

Console.WriteLine("===== Trip Summaries =====");
foreach (string summary in summaries)
{
    Console.WriteLine(summary);
}
Console.WriteLine();

// Task 3: Filter, sort by days from low to high, then select names.
var affordableDestinations = trips
    .Where(trip => trip.Budget <= 200000)
    .OrderBy(trip => trip.Days)
    .Select(trip => trip.Destination);

Console.WriteLine("===== Affordable Destinations by Days =====");
foreach (string destination in affordableDestinations)
{
    Console.WriteLine(destination);
}
Console.WriteLine();

// Bonus: Transform each trip into its formatted budget per day.
var dailyBudgets = trips.Select(trip =>
    $"{trip.Destination}: Rs. {(trip.Budget / trip.Days).ToString("N2", System.Globalization.CultureInfo.InvariantCulture)} per day");

Console.WriteLine("===== Daily Budgets =====");
Console.WriteLine();
foreach (string dailyBudget in dailyBudgets)
{
    Console.WriteLine(dailyBudget);
}

class Trip
{
    public string Destination { get; set; }
    public int Days { get; set; }
    public decimal Budget { get; set; }

    public Trip(string destination, int days, decimal budget)
    {
        Destination = destination;
        Days = days;
        Budget = budget;
    }
}*/
/*
List<Trip> trips = new List<Trip>
{
    new Trip("Ella", 5, 50000),
    new Trip("Kandy", 3, 30000),
    new Trip("Tokyo", 10, 400000),
    new Trip("Bali", 7, 250000),
    new Trip("Galle", 2, 25000),
    new Trip("Nuwara Eliya", 6, 200000)
};

TripExplorer.Run(trips);
*/
/*
Console.WriteLine("===== Create Trip =====");
Console.WriteLine();

try
{
    Console.WriteLine("Destination:");
    string destination = Console.ReadLine() ?? "";

    Console.WriteLine("Days:");
    int days = int.Parse(Console.ReadLine() ?? "");

    Console.WriteLine("Budget:");
    decimal budget = decimal.Parse(Console.ReadLine() ?? "");

    Trip trip = new Trip(destination, days, budget);
    Console.WriteLine($"Trip created: {trip.Destination} - {trip.Days} days - Rs. {trip.Budget:N2}");
}
catch (FormatException)
{
    Console.WriteLine("Invalid number format.");
}
catch (OverflowException)
{
    Console.WriteLine("Number is outside the supported range.");
}
finally
{
    Console.WriteLine("Trip creation attempt completed.");
}
*/
Trip trip = new Trip("Ella", 5, 100000, 2);
Console.WriteLine($"Valid trip: {trip.Destination}, Budget: {trip.Budget:N2}, Travelers: {trip.Travelers}, Days: {trip.Days}");

Console.WriteLine("===== Three Invalid Operations in One Try =====");
try
{
    trip.SetBudget(-1000);
    trip.SetTravelers(0); // Not reached: SetBudget throws first.
    trip.SetDays(-3);     // Not reached either.
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

// Separate attempts demonstrate the other two validation rules.
Console.WriteLine("===== Invalid Travelers =====");
try
{
    trip.SetTravelers(0);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("===== Invalid Days =====");
try
{
    trip.SetDays(-3);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine($"After rejected changes: Budget: {trip.Budget:N2}, Travelers: {trip.Travelers}, Days: {trip.Days}");

trip.SetBudget(0);
trip.SetTravelers(1);
trip.SetDays(1);
Console.WriteLine($"Allowed boundaries: Budget: {trip.Budget:N2}, Travelers: {trip.Travelers}, Days: {trip.Days}");

Console.WriteLine("===== Trip Confirmation =====");
Trip plannedTrip = new Trip("Ella", 5, 100000, 2);

// Check below budget, exactly on budget, and over budget.
foreach (decimal plannedCost in new decimal[] { 80000, 100000, 120000 })
{
    plannedTrip.SetPlannedCost(plannedCost);
    Console.WriteLine($"Planned cost: Rs. {plannedTrip.PlannedCost:N2}");
    try
    {
        plannedTrip.ConfirmTrip();
        Console.WriteLine("Trip confirmed.");
    }
    catch (InsufficientTripBudgetException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
