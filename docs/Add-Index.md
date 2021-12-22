---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Add-Index

## SYNOPSIS
Enumerates items from the pipeline.

## SYNTAX

```
Add-Index -InputObject <Object> [-StartingIndex <Int32>] [-Step <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Enumerates items from the pipeline.

## EXAMPLES

### Example 1
```powershell
"a".."e" | Add-Index

Index Value
----- -----
    0     a
    1     b
    2     c
    3     d
    4     e
```

This example enumerates letters from 'a' to 'e'.

## PARAMETERS

### -InputObject
The input object.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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
