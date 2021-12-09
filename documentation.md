## Add-Index
Adds numbers to the items from the pipeline. The `StartingIndex` parameter specifies the starting number. The `Step` parameter specifies the number to add each iteration.
### Aliases
-  `aix`
-  `enumerate`

### Examples
```powershell
PS C:\> "A".."Z" | Add-Index -StartingIndex 1

Index Item
----- ----
    1    A
    2    B
    3    C
    4    D
    5    E
    6    F
    7    G
    8    H
    9    I
   10    J
   11    K
   12    L
   13    M
   14    N
   15    O
   16    P
   17    Q
   18    R
   19    S
   20    T
   21    U
   22    V
   23    W
   24    X
   25    Y
   26    Z
```

## Chain-Pipe
Adds a collection of items to the end of the current pipeline.
### Aliases
-  `chain`

### Examples
```powershell
PS C:\> "a".."z" | Chain-Pipe ("A".."Z") | Join-String

abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ
```

## Join-Pipe
Zips items from the pipe with the items in a collection.
### Aliases
-  `zip`

### Examples
```powershell
PS C:\> 1..10 | Join-Pipe (10..1)

Left Right
---- -----
   1    10
   2     9
   3     8
   4     7
   5     6
   6     5
   7     4
   8     3
   9     2
  10     1
```

## Measure-Count
Counts the number of items in a collection or the pipeline.
### Aliases
-  `len`

### Examples
```powershell
PS C:\> 1..5 | Measure-Count
5
PS C:\> $arr = 1, 2, 3, 4, 5
PS C:\> Measure-Count $arr
5
```

## Measure-Max
Calculates the object with the highest value.
### Aliases
-  `max`

### Examples
```powershell
PS C:\> $arr = 1,5,9,2,3,4
PS C:\> Measure-Max $arr
9
PS C:\> $arr | Measure-Max
9
PS C:\> Measure-Max a b c d e f g
g
```

## Measure-Min
Calculates the object with the lowest value in a collection or the pipeline.
### Aliases
-  `min`

### Examples
```powershell
PS C:\> $arr = 5,2,3,1,-1,0
PS C:\> Measure-Min $arr
-1
PS C:\> 1..5 | Measure-Min
1
PS C:\> Measure-Min e f g a b
a
```

## Skip-Item
Skips items from the pipeline.
### Aliases
-  `skip`

### Examples
```powershell
PS C:\> 1..20 | Skip-Item { "$_".length -ne 2 }

10
11
12
13
14
15
16
17
18
19
20
```

## Switch-Pipe
Alternates between the current pipe and a provided collection. By default, items will be taken from each side 1 by 1. First item taken is always from the pipe. The `-Left` and `-Right` parameters specify how many items to take from the respective sources in each alternation. If the `-DiscardRest` flag is set, no value will be produced after an alternation produces incomplete values (e.g a source runs out of items/ it doesn't have enough items to produce).
### Aliases
-  `alt`
-  `swp`

### Examples
```powershell
PS C:\> $left = "left 1", "left 2", "left 3"
PS C:\> $right = "right 1", "right2", "right3", "right4", "right5"
PS C:\> $left | Switch-Pipe $right -Right 2 -DiscardRest

left 1
right 1
right2
left 2
right3
right4
```

## Take-Item
Takes items from the pipeline, ignoring the rest.
### Aliases
-  `take`

### Examples
```powershell
PS C:\> 1..20 | Take-Item { "$_".length -ne 2 }

1
2
3
4
5
6
7
8
9
```

## Test-All
Asserts that every item from the pipeline fits within a criteria.


The criteria can be a script block returning true/false or a value that will be checked for equality.
### Aliases
-  `all`

### Examples
```powershell
PS C:\> $text = "banana is good
>> banana is life
>> my brother was beaten badly with a banana wielding man"
>>
PS C:\> $text.split("`n") | Test-All { $_.contains("banana") }

True
```

## Test-Any
Checks if any item from the pipeline satisfies the given criteria. The criteria can be a script block returning true/false or a value that will be checked for equality. The script block won't be executed after it returns true.
### Aliases
-  `any`

### Examples
```powershell
PS C:\> 33..53 | Test-Any { $_ % 5 -eq 0 }

True
```

## Test-None
Tests if no item in the pipeline satisfies the criteria given. The criteria can be a script block returning true/false or a value that will be checked for equality. The script block will not be executed after it returns false.
### Aliases
-  `none`

### Examples
```powershell
PS C:\> -10..5 | Test-None { $_ -lt 0 }

False
```
