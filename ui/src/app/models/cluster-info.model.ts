export interface Cluster {
  version: string;
  nodeCount: number;
  nodes: Node[];
  namespaces: Namespace[];
}

export interface Node {
  name: string;
  labels: Record<string, string>;
  conditions: Condition[];
  capacity: ResourceList;
  allocatable: ResourceList;
}

export interface Condition {
  type: string;
  status: string;
  reason: string;
  message: string;
  lastTransitionTime: string;
}

export interface ResourceList {
  cpu: string;
  "ephemeral-storage": string;
  "hugepages-1Gi": string;
  "hugepages-2Mi": string;
  memory: string;
  pods: string;
}

export interface Namespace {
  name: string;
  status: string;
}
