# Push image first
docker tag kubernetesassignment-app:latest baltzar1994/kubernetesassignment-app:latest
docker push baltzar1994/kubernetesassignment-app:latest

# Create EKS cluster
eksctl create cluster --name kubernetesassignment --region eu-west-1 --nodegroup-name worker-nodes --node-type t2.small --nodes 2

# Deploy manifests
kubectl apply -f k8s/namespace.yaml
kubectl apply -f k8s/mongo-pvc.yaml
kubectl apply -f k8s/mongo-deployment.yaml
kubectl apply -f k8s/app-deployment.yaml

# Get external IP
kubectl get svc todoapp-service -n todoapp


eksctl utils associate-iam-oidc-provider --region=eu-west-1 --cluster=kubernetesassignment --approve

eksctl create addon --name aws-ebs-csi-driver --cluster kubernetesassignment --region eu-west-1 --service-account-role-arn arn:aws:iam::584156787193:role/AmazonEKS_EBS_CSI_DriverRole --force


9404946C8863624B77DA1CCCC7A1359F


aws iam create-role --role-name AmazonEKS_EBS_CSI_DriverRole \
  --assume-role-policy-document '{
    "Version": "2012-10-17",
    "Statement": [
      {
        "Effect": "Allow",
        "Principal": {
          "Federated": "arn:aws:iam::584156787193:oidc-provider/oidc.eks.eu-west-1.amazonaws.com/id/'$OIDC_ID'"
        },
        "Action": "sts:AssumeRoleWithWebIdentity",
        "Condition": {
          "StringEquals": {
            "oidc.eks.eu-west-1.amazonaws.com/id/9404946C8863624B77DA1CCCC7A1359F:sub": "system:serviceaccount:kube-system:ebs-csi-controller-sa"
          }
        }
      }
    ]
  }'

# Attach policy
aws iam attach-role-policy --role-name AmazonEKS_EBS_CSI_DriverRole \
  --policy-arn arn:aws:iam::aws:policy/service-role/AmazonEBSCSIDriverPolicy