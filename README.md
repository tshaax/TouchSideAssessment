# TouchSideAssessment
The project is a Console application that accepts text file and print out the following:
- Most frequent word: {word} occurred {x} times
- Most frequent 7-character word: {word} occurred {x} times
- Highest scoring word(s) (according to the score table): {word} with a score of {x}

# Performance 
The project uses dictionaries instead of using arrays because it lookups items based on a key value and not by index.
Furthermore, the project optimized the reading of the file content using streamreader which is more effective in reding large files.
The for loops were used instead of foreach to iterate the KeyValuePair on the dictionary. 

The peformance can be further be improved by substituting the LINQ queries with for loops index element. 

