# NinetiesTV

## A C# LINQ Exercise

In this exercise you'll write LINQ to explore a few well-known television shows from bygone era.

### The Data

The data we'll be exploring consists of a list of 31 tv shows from the 90s. Each show record contains the following information:

* Name of the show
* Year the show started
* Year the show ended
* Genres for the show
* Number of episodes
* IMDB Rating

#### A CSV File

The data is located in a file called [data.csv](./data.csv). It's a _CSV file_. CSV stands for **C**omma **S**eparated **V**alues. It's a text file in which each line (also known as a _"row"_) is an individual record, and fields in each record are separated by commas. The first row in a CSV file is a _header_ row. It contains names for each field in the records that follow.

Like JSON, CSV is a popular format for storing data in a simple text file. One advantage of CSV over JSON is that a CSV file can be opened by a spreadsheet program such as Microsoft Excel. On the other hand, an advantage of JSON over CSV is that a JSON file can store more complex data such as objects and arrays.

It's recommended that you open the `data.csv` file (in VS Code or in a spreadsheet application) and keep it handy to help you to verify the correctness of your code. If you use VS Code you might want to install the [Rainbow CSV](https://marketplace.visualstudio.com/items?itemName=mechatroner.rainbow-csv) extension to make reading the file a little easier.

#### Loading the Data

In order to use LINQ to explore the tv data, the data must be loaded into a collection of C# objects. The code provided in this repo handles that for you. The `GetShows()` static method of the `DataLoader` class will read the data from the CSV file and load it into a `List<Show>` where `Show` is a class that contains properties to contain the data for a single show.

**YOU	DO _NOT_ NEED TO READ, UNDERSTAND - OR EVEN LOOK AT - THE `DataLoader` CLASS. UNDERSTANDING THAT CODE IS _NOT_ ONE OF THE OBJECTIVES OF THIS EXERCISE.**

You should take a look at the `Show` class though.

### The Exercise

All code that you will write will be in `Program.cs` It is broken up into the following sections:

1. The first section contains code that:
	* gets a `List<Show>`
	* calls several methods that accept that list as an argument
	* Prints the results of each method along with a header to describe the data that's being printed
1. The main Exercises block. This is where you'll write your LINQ code
1. A few challenges for you to try if you complete the rest of the exercises
1. A class used for printing results

Your task is to read and understand the existing code in `Program.cs`, and write code in each "Exercise" method that satisfies that method's comment.

> **NOTE:** Make sure you run the code regularly.
