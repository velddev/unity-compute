# unity-computer
A code simulator.

## Set rules in unity compute
This document is made to highlight and make it clear that the mechanics are consistent and designed according to our initial idea.  

If anything doesn’t work like documented here, please fix it.

### Execute Nodes
#### Input Nodes
There’s a constraint of only one input node, this means having multiple input nodes will, and shall never happen. Input nodes can be connected to multiple times.

#### Output Nodes
Output nodes can only connect to one input node. This means current can be redirected to this component.

### Data Nodes
#### Types
The available types are: 
- Object 
- String 
- Char 
- Integer 
- Byte 
- Bool
Other types than this should be made by the user.

#### Input Nodes
A function node only have one node, otherwise it’ll cause interference with other nodes.

#### Output Nodes
Output nodes can be redirected as many times as you want, this means you could re-use the same variable whenever it’s available.

### Function Nodes
#### Execution Nodes
Function nodes always have either at least one output execution node. Input execution nodes are optional. There can be multiple output execution nodes.

#### Getter Nodes
Getter nodes do not have any execution nodes attaches, this means they do not execute any function, they just hold a value.
