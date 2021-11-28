---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Add-Index

## SYNOPSIS
Adds numbers to the items from the pipeline.

## SYNTAX

```
Add-Index [-Input] <Object> [-StartingIndex <Int32>] [-Step <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Adds numbers to the items from the pipeline.
The `StartingIndex` parameter specifies the starting number.
The `Step` parameter specifies the number to add each iteration.

## EXAMPLES

### Example 1
This example numbers the letters in the Latin alphabet starting from 1.

```powershell
PS C:\> "A".."Z" | Add-Index -StartingIndex 1
```

```

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

## PARAMETERS

### -Input
The input from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -StartingIndex
The starting index.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Step
the value that will be added to the current index each iteration.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object

## OUTPUTS

### Itertools.IndexEntry

## NOTES

## RELATED LINKS
