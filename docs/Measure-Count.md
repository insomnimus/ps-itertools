---
external help file: Itertools.dll-Help.xml
Module Name: itertools
online version:
schema: 2.0.0
---

# Measure-Count

## SYNOPSIS
Counts the number of items in a collection or the pipeline.

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
Counts the number of items in a collection or the pipeline.

## EXAMPLES

### Example 1
```powershell
PS C:\> 1..5 | Measure-Count
5
PS C:\> $arr = 1, 2, 3, 4, 5
PS C:\> Measure-Count $arr
5
```

## PARAMETERS

### -InputObject
The pipeline object.

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
