using Part1;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Part1
{
    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;
        public Recipe()
        {
            // Initialize empty arrays for ingredients, quantities, units, and steps
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
         }
        public void RecipeDetails()
        {
            // Prompt the user to enter the number of ingredients
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Initialize the below arrays with the correct size
            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Prompt the user to enter the details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Ingredient name: ");
                ingredients[i] = Console.ReadLine();

                Console.Write("Ingredient quantity: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.Write("Select the Unit of measurement: ");
                Console.WriteLine("(mg).Milligram, (g).Gram, (kg).Killogram, (ml).Millilitre, (l).Litre");
                units[i] = Console.ReadLine();
            }

            // Prompt the user to enter the number of steps
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Initialize the steps array with the correct size
            steps = new string[numSteps];

            // Prompt the user to enter the details for each step
            for (int i = 0; i < numSteps; i++)
            {

                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }
        public void DisplayResults()
        {
            // Display the ingredients and quantities results
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"- {quantities[i]} {units[i]} of {ingredients[i]}");
            }

            // Display the steps results
            Console.WriteLine("Steps: ");
            for (int i = 0; i < steps.Length; i++) 
            {
                Console.WriteLine($"- {steps[i]}");
            }
        }
        public void ScaleRecipe(double factor)
        {
            // Multiply all the quantities by the scaling factor
            for (int i = 0; i < quantities.Length; i++) {
                quantities[i] *= factor;
            }
        }
        public void ResetQuantities(double factor)
        {
            // Reset all the quantities to their original values
            for (int i = 0; i < quantities.Length; i++) 
            {
                quantities[i] /= factor;
            }
        }
        public void ClearRecipe()
        {
            // Reset all the arrays to empty
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        double factor = 0;

        while (true)
        {
            Console.WriteLine("1. Recipe details");
            Console.WriteLine("2. Display recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset quantities");
            Console.WriteLine("5. Clear recipe");
            Console.WriteLine("6. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    recipe.RecipeDetails();
                    break;
                case "2":
                    recipe.DisplayResults();
                    break;
                case "3":
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    /*double*/ factor = double.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    break;
                case "4":
                    recipe.ResetQuantities(factor);
                    break;
                case "5":
                    recipe.ClearRecipe();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using the application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        
        }
    }
}