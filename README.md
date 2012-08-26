SoundEx algorithms
==================

A .Net implementation of various SoundEx algorithms.

Copyright (c) Richard Birkby, 2002-2012. Apache licensed.


Introduction
------------

Every computer scientist has heard of SoundEx. It is perhaps the most infamous text 
processing/searching algorithm around. SoundEx promises a great deal - that of 
matching words with similar sounding words, but actually delivers, at best, a 
large number of inaccurate matches. Even though SoundEx was patented, variations 
have arisen, whether through poor understanding of the algorithm or through 
attempts to improve its accuracy. Thus, this article presents four popular 
implementations of SoundEx written in C# and .Net to allow you to perform your 
own benchmarking on your own data sets.

History
-------

SoundEx was originally invented to find alternative spellings for surnames. 
The problem came from mis-spellings on US census returns and therefore the 
SoundEx algorithms are biased towards English speaking names. There are 
further variants for some western European languages, but in general the 
algorithm has never been considered a panacea for all fuzzy text matching.

Core algorithm
--------------

Most SoundEx algorithms are a variant on the following

* Retain the first letter of the name
* Drop all vowels, and h, y in all but the first letter
* Replace b,f,p,v with the number 1
* Replace c,g,j,k,q,s,x,z with the number 2
* Replace d and t with the number 3
* Replace l with 4, m and n with 5 and r with 6
* Finally convert to a 4 character code like {letter}{number}{number}{number} by truncation

Some algorithms have grouping and adjacent letter rules in addition.