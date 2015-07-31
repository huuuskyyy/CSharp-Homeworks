Problem 1 – Frames
We are given N rectangular frames of different sizes (duplicates are allowed). Write a program to find all unique ways we can reorder these frames by exchanging their order and flipping them.
For example, if we have 3 frames of sizes (2, 3), (2, 2) and (3, 2), we can reorder them in the following 12 unique ways:
</br>(2, 2) | (2, 3) | (2, 3)  	(2, 2) | (2, 3) | (3, 2)	  (2, 2) | (3, 2) | (2, 3)  	(2, 2) | (3, 2) | (3, 2)
</br>(2, 3) | (2, 2) | (2, 3)	  (2, 3) | (2, 2) | (3, 2)	  (2, 3) | (2, 3) | (2, 2)	  (2, 3) | (3, 2) | (2, 2)
</br>(3, 2) | (2, 2) | (2, 3)	  (3, 2) | (2, 2) | (3, 2)	  (3, 2) | (2, 3) | (2, 2)	  (3, 2) | (3, 2) | (2, 2)
</br>Input
The input data starts with an integer N at the first line. At the next N lines the sizes of the input frames are given (two integers separated by space describes each frame).
The input data will always be valid and in the described format. There is no need to check it explicitly.
Output
The output data starts with an integer K at the first line – the number of unique orderings of the frames. At the next K lines the unique orderings of the frames should be given in lexicographical order in the format shown in the example below.
Constraints
</br>•	All numbers in the input be in the range [1…6].
</br>•	Allowed working time for your program: 0.35 seconds.
</br>•	Allowed memory: 16 MB.
</br>Example
</br>Input	Output
</br>3
</br>2 3
</br>2 2
</br>3 2	12
</br>(2, 2) | (2, 3) | (2, 3)
</br>(2, 2) | (2, 3) | (3, 2)
</br>(2, 2) | (3, 2) | (2, 3)
</br>(2, 2) | (3, 2) | (3, 2)
</br>(2, 3) | (2, 2) | (2, 3)
</br>(2, 3) | (2, 2) | (3, 2)
</br>(2, 3) | (2, 3) | (2, 2)
</br>(2, 3) | (3, 2) | (2, 2)
</br>(3, 2) | (2, 2) | (2, 3)
</br>(3, 2) | (2, 2) | (3, 2)
</br>(3, 2) | (2, 3) | (2, 2)
</br>(3, 2) | (3, 2) | (2, 2)

