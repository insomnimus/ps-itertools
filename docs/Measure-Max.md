---
external help file: Itertools-help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Measure-Max

## SYNOPSIS
Finds the item with the highest value from the pipeline.

## SYNTAX

### pipe (Default)
```
Measure-Max -InputObject <Object> [<CommonParameters>]
```

### nopipe
```
Measure-Max -Items <Object[]> [<CommonParameters>]
```

## DESCRIPTION
Finds the item with the highest value from the pipeline.

## EXAMPLES

### Example 1
```powershell
$nums = 1, -2, 50, 23, -10, 132
$nums | Measure-Max
132
```

This example calculates the highest value in a list of numbers.

## PARAMETERS

### -InputObject
The pipeline object.

```yaml
Type: Object
Parameter Sets: pipe
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Items
A collection of objects.

```yaml
Type: Object[]
Parameter Sets: nopipe
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object

### System.Object[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
