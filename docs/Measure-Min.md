---
external help file: Itertools.dll-help.xml
Module Name: itertools
online version:
schema: 2.0.0
---

# Measure-Min

## SYNOPSIS
Calculates the object with the lowest value.

## SYNTAX

### pipe (Default)
```
Measure-Min -InputObject <Object> [<CommonParameters>]
```

### nopipe
```
Measure-Min -Items <Object[]> [<CommonParameters>]
```

## DESCRIPTION
Calculates the object with the lowest value in a collection or the pipeline.

## EXAMPLES

### Example 1
```powershell
PS C:\> $arr = 5,2,3,1,-1,0
PS C:\> Measure-Min $arr
-1
PS C:\> 1..5 | Measure-Min
1
PS C:\> Measure-Min e f g a b
a
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
