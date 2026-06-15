// Exercise05 - Grade Calculation
// Demonstrates if/else-if/else plus a switch expression with pattern matching.

Console.Write("Enter score from 0 to 100: ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int score) || score < 0 || score > 100)
{
    Console.WriteLine("Invalid score. Using sample score 86.");
    score = 86;
}

string gradeUsingIf;
if (score >= 90)
{
    gradeUsingIf = "A";
}
else if (score >= 80)
{
    gradeUsingIf = "B";
}
else if (score >= 70)
{
    gradeUsingIf = "C";
}
else if (score >= 60)
{
    gradeUsingIf = "D";
}
else
{
    gradeUsingIf = "F";
}

string gradeUsingSwitch = score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    _ => "F"
};

Console.WriteLine($"Score: {score}");
Console.WriteLine($"Grade from if/else: {gradeUsingIf}");
Console.WriteLine($"Grade from switch expression: {gradeUsingSwitch}");
