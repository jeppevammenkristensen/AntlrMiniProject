grammar Create;

create  : 'create' createType? IDENTIFIER  with EOF;
with : 'with' declarationlist ;
declaration: propertydeclaration ;
propertydeclaration: PROPERTY  identifiernamedeclaration+ ;
declarationlist: declaration ( ',' declaration )* ; 
identifiernamedeclaration: IDENTIFIER ':' identifiertype ;
identifiertype : IDENTIFIER'?'? ;
createType : class| interface | record;
class: 'class';
interface: 'interface';
record: 'record';

UPPERCASE : [A-Z] ; 
LOWERCASE : [a-z] ;
DIGIT : [0-9] ;
fragment UNDERSCORE : '_';
fragment IDENTIFIERFIRST : (UPPERCASE|LOWERCASE|UNDERSCORE) ;
fragment IDENTIFIERNOTFIRST : (IDENTIFIERFIRST|DIGIT) ;
 
PROPERTY: 'property' ;

IDENTIFIER : (IDENTIFIERFIRST) (IDENTIFIERNOTFIRST)*  ; 
WORD                : (LOWERCASE | UPPERCASE)+ ;  

WHITESPACE          : (' '|'\t')+ -> skip ;

