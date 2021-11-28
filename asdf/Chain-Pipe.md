---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Chain-Pipe

## SYNOPSIS
Adds a collection of items to the end of the current pipeline.

## SYNTAX

```
Chain-Pipe [-Values] <System.Collections.Generic.List`1[System.Object]> [-Input] <Object> [<CommonParameters>]
```

## DESCRIPTION
Adds a collection of items to the end of the current pipeline.

## EXAMPLES

### Example 1
```
PS C:\> "a".."z" | Chain-Pipe ("A".."Z") | Join-String

abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ
```

## PARAMETERS

### -Input
The input from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Values
A collection of objects to chain at the end of this pipe.

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

### System.Object
## NOTES

## RELATED LINKS
