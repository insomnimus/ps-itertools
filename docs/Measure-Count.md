---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Measure-Count

## SYNOPSIS
Calculates the number of items in the pipeline, ignoring their values.

## SYNTAX

### nopipe (Default)
```
Measure-Count [-Items] <Object[]> [<CommonParameters>]
```

### pipe
```
Measure-Count [-InputObject] <Object> [<CommonParameters>]
```

## DESCRIPTION
Calculates the number of items in the pipeline, ignoring their values.

## EXAMPLES

### Example 1
```powershell
1..50 | Measure-Count
50
```

This example counts the number of items in the pipeline.

## PARAMETERS

### -InputObject
The object frmo pipeline.

```yaml
Type: Object
Parameter Sets: pipe
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Items
A collection of items to count.

```yaml
Type: Object[]
Parameter Sets: nopipe
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

### System.UInt32

## NOTES

## RELATED LINKS
