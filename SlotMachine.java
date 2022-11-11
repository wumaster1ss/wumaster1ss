/*
 *SlotMachine.java
 */

import java.util.*;

/**  
   This interactive program will:
    
   - print an introduction

   - prompt the user to enter the amount of money
   - display the symbols that are matched 
   - calculate the amount won or lost

   - repeat until the user chooses to quit
   - print a goodbye message when the user quits.
    
   @author Shawn Wu
   @version 2/8/21
*/
public class SlotMachine {

    /**
      The start point for this application.
        
      @param args
   */


    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        displayIntro();
        int symbol1 = 0;
        int symbol2 = 0;
        int symbol3 = 0;
        int plays = 0;
        double newTotal = 0;
        printStartMessage();
        double initial = promptForInitial(console, 0.25, 20, initialAmount());
        double currentTotal = initial;
        while (currentTotal >= 0.25) {
            double bet = promptForBet(console);
            if (bet != 4) {       
                printResult();
                symbol1 = displaySymbol();
                symbol2 = displaySymbol();
                symbol3 = displaySymbol();
                newTotal = newTotal(symbol1, symbol2, symbol3, currentTotal, bet);
                currentTotal = newTotal;
                plays++;
            } else {
                currentTotal = 0; 
            }
        } 
        console.close();
        displayResults(plays, initial, newTotal);
    }
   
    /**
      Displays an introduction for the program.
   */
   
    public static void printResult() {
        System.out.print("Result : ");
    }
   
    /**
      Prints out the prompt message.
      @return if the user inputs an invalid input
   */
   
    public static String initialAmount() {
        String invalidWarning = "\nHow much do you have for the slots today?";
        String budget = "\n(Enter a value between 0.25 and 20.00):";
        String value = "\nNot a valid input; try again";
        return invalidWarning + value + budget;
   
    }
   
    /**
      Displays an introduction for the program.
   */
         
    public static void displayIntro() {
        System.out.println("This program simulates a slot machine!");
        System.out.println("You can play until you run out of money or "  
            + "choose to quit.");
        System.out.println();
    }
    
    /**
      Prints the start for the program.
   */
   
    public static void printStartMessage() {
        System.out.println("How much do you have for the slots today?");
        System.out.print("(Enter a value between 0.25 and 20.00): $");
    }
   
    /**
      Displays controls the user input with in the desired amont.
      @param console used to capture the users input
      @param lower the min value
      @param upper the max value
      @param messagePrint 
      @return the user input if not valid value is entered
    */
    
    public static double promptForInitial(Scanner console, double lower, double upper, String messagePrint) {
        double input = 0;      
        while (input < lower || input > upper) {
            while (!console.hasNextDouble()) {
                console.next();
                System.out.print(messagePrint);
            }
            input = console.nextDouble();
            if (input < lower || input > upper) {
                System.out.print(messagePrint);
            } 
        }
        System.out.println();
        System.out.printf("Okay, you are starting with $%.2f.", input);
        System.out.println(" Good luck!\n");

        return input;
    }
    
    /**
      Displays the choices for betting.
      @param console used to capture user input
      @return the value of the bet
   */
   
    public static double promptForBet(Scanner console) {
        double bet = 0;
        System.out.println();
        System.out.println("Choices for bets are: ");
        System.out.println("1) $0.25");
        System.out.println("2) $0.50");
        System.out.println("3) $1.00");
        System.out.println("4) Quit");
        System.out.print("\nEnter your choice: ");
        
        String warningMessage = ("\n1) $0.25\n2) $0.50\n3) $1.00\n4) Quit\n" 
            + "\nInvalid input. Please try again\nEnter your choice:");
     
        bet = promptForInitial(console, 1, 4, warningMessage);
          
        System.out.println();
        if (bet == 1) {
            return 0.25;
        } else if (bet == 2) {
            return 0.50;
        } else if (bet == 3) {
            return 1.00;
        } else if (bet == 4) {
            return 4;
        }
        else {
            return 0;
        }   
         
    } 
    
    /**
      Displays the symbols for the program.
      @return the symbols
   */
   
    public static int displaySymbol() {
        Random rand = new Random();
        int symbol1 = rand.nextInt(6);
        if (symbol1 == 0) {
            System.out.print("Cherries ");
        } else if (symbol1 == 1) {
            System.out.print("Plums ");
        } else if (symbol1 == 2) {
            System.out.print("Melons ");
        } else if (symbol1 == 3) {
            System.out.print("Moons ");
        } else if (symbol1 == 4) {
            System.out.print("Bars ");
        } else {
            System.out.print("Stars ");
        }  
          
        System.out.print(" ");    
   
        return symbol1;         
    }
    
     /**
      Shows the matches for the program.
      @param symbol1
      @param symbol2
      @param symbol3
      @param currentTotal
      @param bet
      @return the winning or losing amount toward the newtotal
    */
      
    public static double newTotal(int symbol1, int symbol2, int symbol3, double currentTotal, double bet) {
        double newTotal;
        double youWon2;
        double youWon3;
        System.out.println();
        if (symbol1 == symbol2 && symbol2 == symbol3) {
            System.out.println("\nAll three match!");
            youWon3 = bet * 3;
            newTotal = (currentTotal + bet * 3);
            System.out.printf("You won : $%.2f", youWon3);
            System.out.printf("\nNew total: $%.2f", newTotal); 
            System.out.println();       
        } else if (symbol1 == symbol2 || symbol2 == symbol3 || symbol1 == symbol3) {
            System.out.println("\nTwo matched!");
            youWon2 = bet * 2;
            newTotal = (currentTotal + youWon2);
            System.out.printf("You won : $%.2f", youWon2);
            System.out.printf("\nNew total: $%.2f", newTotal); 
            System.out.println(); 
        } else {         
            System.out.println("\nSorry, no matches.\nYou lost!");
            newTotal = currentTotal - bet;
            System.out.printf("\nNew total: $%.2f", newTotal);
            System.out.println(); 
        }     
      
        return newTotal;
    }

    /**
      Displays the results for the program.
      @param plays
      @param initial
      @param newTotal
   */
   
    public static void displayResults(int plays, double initial, double newTotal) {
        System.out.println();
        System.out.println();
        System.out.println("Overall results:\n ");
        System.out.println("   Total games played:" + plays);
        System.out.println("   You started with " + initial 
            + " and ended with " + newTotal);
        if (newTotal > initial) {
            System.out.println("   You won " + (newTotal - initial));
        } else if (newTotal < initial) {
            System.out.println("   You lost " + (initial - newTotal));
        } else {
            System.out.println("   You broke even!");
        }
    } 
}
