---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Join-Pipe

## SYNOPSIS
Zips items from the pipe with the items in a collection.

## SYNTAX

```
Join-Pipe [-Input] <Object> [-RightValues] <System.Collections.Generic.List`1[System.Object]>
 [<CommonParameters>]
```

## DESCRIPTION
Zips items from the pipe with the items in a collection.

## EXAMPLES

### Example 1
```
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

## PARAMETERS

### -Input
{{ Fill Input Description }}

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -RightValues
A collection to join with the current pipe.

```yaml
Type: System.Collections.Generic.List`1[System.Object]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object
## OUTPUTS

### Itertools.Zip
## NOTES

## RELATED LINKS
