---
external help file: Itertools.dll-help.xml
Module Name: itertools
online version:
schema: 2.0.0
---

# Measure-Max

## SYNOPSIS
Calculates the object with the maximum value.

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
Calculates the object with the highest value.

## EXAMPLES

### Example 1
```powershell
PS C:\> $arr = 1,5,9,2,3,4
PS C:\> Measure-Max $arr
9
PS C:\> $arr | Measure-Max
9
PS C:\> Measure-Max a b c d e f g
g
```

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
