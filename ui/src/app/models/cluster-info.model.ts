export interface ClusterInfo {
    version: string;
    nodes: NodeInfo[];
    namespaces: NamespaceInfo[];
  }
  
  export interface NodeInfo {
    name: string;
    status: string;
    conditions: NodeCondition[];
    // Add other properties as needed (e.g., capacity, allocatable, etc.)
  }
  
  export interface NodeCondition {
    type: string;
    status: string;
    reason: string;
    message: string;
  }
  
  export interface NamespaceInfo {
    name: string;
    status: string;
  }
  